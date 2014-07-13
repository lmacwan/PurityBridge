/// <reference path="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js" />

//  uTube - "The" YouTube Umbraco package for Umbraco
//  JS API for Chromeless player
//
//  Team:
//      Warren Buckley
//      Lee Kelleher
//      Chriztian Steinmeier
//      Morten Christensen

/*
    Controller object for YouTube player 
 */
function uTubePlayer(id) {
	// Misc. constants
	var CONTAINER_CLASS         = ".youTubePlayer";
	var PLAYCONTROL_CLASS       = ".controlDiv";
	var MUTECONTROL_CLASS       = ".muteControl";
	var PROGRESSBAR_CLASS       = ".progressBar";
	var ELAPSED_CLASS           = ".elapsed";
	var STATE_READY             = -1;
	var STATE_ENDED             = 0;
	var STATE_PLAYING           = 1;
	var STATE_PAUSED            = 2;
	var STATE_BUFFERING         = 3;

	this.id = id || 'ytplayer';
	
	this.player                 = _getPlayerReference(id);
	this.container              = $(this.player).parent(CONTAINER_CLASS);
	
	this._setupControls = function() {
		// Grab these to enable use in event methods
		var player              = this;
		var container           = player.container; //This is the container DIV around the flash movie
		var playerDelegate      = this.player;      // Access to the API player
		
		// Accessors to the controls
		player.playPauseButton  = container.find(PLAYCONTROL_CLASS);
		player.muteButton       = container.find(MUTECONTROL_CLASS);
		player.progressBar      = container.find(PROGRESSBAR_CLASS);
		
		// Setup click handlers
		player.playPauseButton.click(function() {
			if (!player.isPlaying()) {
				player.play();
			} else {
				player.pause();
			}
		});
		
		player.muteButton.click(function() {
			var button = $(this);
			if (button.hasClass('mute')) {
				player.mute();
				button.removeClass('mute').addClass('unmute');
			} else if (button.hasClass('unmute')) {
				player.unMute();
				button.removeClass('unmute').addClass('mute');
			}
		});
		
		player.progressBar.click(function(e) {
			var bar     = $(this);
			var ratio   = (e.pageX - bar.offset().left) / bar.outerWidth();
			
			// Set the elapsed bar to the ratio %
			bar.children(ELAPSED_CLASS).width(ratio * 100 + '%');
			
			// With API seek to the actual position
			playerDelegate.seekTo(Math.round(playerDelegate.getDuration() * ratio), true);
			
			// Stop the default click
			return false;
		});
		
		// All set - mark the player as ready
		container.addClass("ready");
	};
	
	// Utility method to check if the container div has the class of playing
	this.isPlaying = function() {
		return this.container.hasClass("playing");
	}
	
	// Standard player method delegations
	this.play   = function() { this.player.playVideo(); };
	this.pause  = function() { this.player.pauseVideo(); };
	this.mute   = function() {
		if (this.player && !this.player.isMuted()) {
			this.player.mute();
		}
	};
	this.unMute = function() {
		if (this.player && this.player.isMuted()) {
			this.player.unMute();
		}
	};
	
	// Handler for state changes
	this.changeState        = function(newState) {
		var container       = this.container;
		var elapsedBar      = container.find(ELAPSED_CLASS);
		var playerDelegate  = this.player;

		switch (newState) {
            //Video unstarted/ready
			case STATE_READY:
				container.addClass('ready');
				break;
            
            // Video ended 
			case STATE_ENDED:
				container.removeClass('ready playing paused buffering').addClass('ended');
				break;
            
            // Video playing 
			case STATE_PLAYING:
				container.removeClass('ready ended paused buffering').addClass('playing');

				// Every second - update the progress bar %
				var updateProgressBar;
				
				updateProgressBar = window.setInterval(function () {
					// Get percentage watched (currentTime/TotalTime)*100 = %
					var percentageWatched = ((playerDelegate.getCurrentTime() / playerDelegate.getDuration()) * 100) + '%';

					// Set width of elapsed bar
					elapsedBar.width(percentageWatched);
				}, 1000);
                break;
            
            // Video paused 
			case STATE_PAUSED:
				container.removeClass('ready ended playing buffering').addClass('paused');
				
				// Stop the 1-second polling to update the progress bar when we are paused
				window.clearInterval(updateProgressBar);
				break;

            // Video buffering  
            case STATE_BUFFERING:
				container.removeClass('ready ended playing paused').addClass('buffering');
                break;
        }
	};
	
	
	// Initialize controls
	this._setupControls();
	
	// Setup callback for readyStateChange events
	this.player.addEventListener('onStateChange', "function(state) { return onYouTubePlayerStateChanged('" + this.id + "', state); }");

	// Return a reference to the YouTube player OR (if the player can not be located)
	// a mock object with stubbed out methods (for silent fails...)
	function _getPlayerReference(id) {
		var emptyFunction   = function() { };
		var domElement      = document.getElementById(id);
		
		return domElement || {
			playVideo:  emptyFunction,
			pauseVideo: emptyFunction,
			mute:       emptyFunction,
			unMute:     emptyFunction,
			isMuted:    function() { return true; }
		};
	}
}

// Object/associative array for accessing multiple players on the same page
var uTubePlayers = { };

// Callback required by API - YouTybe player calls this when ready
function onYouTubePlayerReady(playerID) {
	// Create a new player controller
	uTubePlayers[playerID] = new uTubePlayer(playerID);
}

// This one we've setup ourselves
function onYouTubePlayerStateChanged(playerID, state) {
	uTubePlayers[playerID].changeState(state);
}