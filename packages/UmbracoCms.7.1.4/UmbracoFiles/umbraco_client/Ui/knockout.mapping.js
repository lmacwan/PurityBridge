/// Knockout Mapping plugin v2.2.4
/// (c) 2012 Steven Sanderson, Roy Jacobs - http://knockoutjs.com/
/// License: MIT (http://www.opensource.org/licenses/mit-license.php)
(function(d){"function"===typeof require&&"object"===typeof exports&&"object"===typeof module?d(require("knockout"),exports):"function"===typeof define&&define.amd?define(["knockout","exports"],d):d(ko,ko.mapping={})})(function(d,e){function u(a,c){for(var b in c)c.hasOwnProperty(b)&&c[b]&&(b&&a[b]&&"array"!==e.getType(a[b])?u(a[b],c[b]):a[b]=c[b])}function A(a,c){var b={};u(b,a);u(b,c);return b}function H(a,c){options=A({},a);for(var b=K.length-1;0<=b;b--){var d=K[b];options[d]&&(options[""]instanceof
Object||(options[""]={}),options[""][d]=options[d],delete options[d])}c&&(options.ignore=j(c.ignore,options.ignore),options.include=j(c.include,options.include),options.copy=j(c.copy,options.copy));options.ignore=j(options.ignore,g.ignore);options.include=j(options.include,g.include);options.copy=j(options.copy,g.copy);options.mappedProperties=options.mappedProperties||{};return options}function j(a,c){"array"!==e.getType(a)&&(a="undefined"===e.getType(a)?[]:[a]);"array"!==e.getType(c)&&(c="undefined"===
e.getType(c)?[]:[c]);return d.utils.arrayGetDistinctValues(a.concat(c))}function B(a,c,b,f,h,x){var C="array"===e.getType(d.utils.unwrapObservable(c)),x=x||"";if(e.isMapped(a))var k=d.utils.unwrapObservable(a)[n],b=A(k,b);var g=function(){return b[f]&&b[f].create instanceof Function},o=function(a){var e=D,E=d.dependentObservable;d.dependentObservable=function(a,b,c){c=c||{};a&&"object"==typeof a&&(c=a);var f=c.deferEvaluation,L=!1;c.deferEvaluation=!0;a=new I(a,b,c);if(!f){var h=a,a=I({read:function(){L||
(d.utils.arrayRemoveItem(e,h),L=!0);return h.apply(h,arguments)},write:h.hasWriteFunction&&function(a){return h(a)},deferEvaluation:!0});e.push(a)}return a};d.dependentObservable.fn=I.fn;d.computed=d.dependentObservable;a=b[f].create({data:a||c,parent:h});d.dependentObservable=E;d.computed=d.dependentObservable;return a},v=function(){return b[f]&&b[f].update instanceof Function},r=function(a,e){var E={data:e||c,parent:h,target:d.utils.unwrapObservable(a)};d.isWriteableObservable(a)&&(E.observable=
a);return b[f].update(E)};if(k=F.get(c))return k;f=f||"";if(C){var C=[],p=!1,i=function(a){return a};b[f]&&b[f].key&&(i=b[f].key,p=!0);d.isObservable(a)||(a=d.observableArray([]),a.mappedRemove=function(b){var c=typeof b=="function"?b:function(a){return a===i(b)};return a.remove(function(a){return c(i(a))})},a.mappedRemoveAll=function(b){var c=y(b,i);return a.remove(function(a){return d.utils.arrayIndexOf(c,i(a))!=-1})},a.mappedDestroy=function(b){var c=typeof b=="function"?b:function(a){return a===
i(b)};return a.destroy(function(a){return c(i(a))})},a.mappedDestroyAll=function(b){var c=y(b,i);return a.destroy(function(a){return d.utils.arrayIndexOf(c,i(a))!=-1})},a.mappedIndexOf=function(b){var c=y(a(),i),b=i(b);return d.utils.arrayIndexOf(c,b)},a.mappedCreate=function(b){if(a.mappedIndexOf(b)!==-1)throw Error("There already is an object with the key that you specified.");var c=g()?o(b):b;if(v()){b=r(c,b);d.isWriteableObservable(c)?c(b):c=b}a.push(c);return c});var k=y(d.utils.unwrapObservable(a),
i).sort(),l=y(c,i);p&&l.sort();var p=d.utils.compareArrays(k,l),k={},j,w=d.utils.unwrapObservable(c),t={},u=!0,l=0;for(j=w.length;l<j;l++){var m=i(w[l]);if(void 0===m||m instanceof Object){u=!1;break}t[m]=w[l]}w=[];l=0;for(j=p.length;l<j;l++){var m=p[l],q,s=x+"["+l+"]";switch(m.status){case "added":var z=u?t[m.value]:G(d.utils.unwrapObservable(c),m.value,i);q=B(void 0,z,b,f,a,s);g()||(q=d.utils.unwrapObservable(q));s=M(d.utils.unwrapObservable(c),z,k);w[s]=q;k[s]=!0;break;case "retained":z=u?t[m.value]:
G(d.utils.unwrapObservable(c),m.value,i);q=G(a,m.value,i);B(q,z,b,f,a,s);s=M(d.utils.unwrapObservable(c),z,k);w[s]=q;k[s]=!0;break;case "deleted":q=G(a,m.value,i)}C.push({event:m.status,item:q})}a(w);b[f]&&b[f].arrayChanged&&d.utils.arrayForEach(C,function(a){b[f].arrayChanged(a.event,a.item)})}else if(N(c)){a=d.utils.unwrapObservable(a);if(!a){if(g())return p=o(),v()&&(p=r(p)),p;if(v())return r(p);a={}}v()&&(a=r(a));F.save(c,a);O(c,function(f){var e=x.length?x+"."+f:f;if(-1==d.utils.arrayIndexOf(b.ignore,
e))if(-1!=d.utils.arrayIndexOf(b.copy,e))a[f]=c[f];else{var h=F.get(c[f])||B(a[f],c[f],b,f,a,e);if(d.isWriteableObservable(a[f]))a[f](d.utils.unwrapObservable(h));else a[f]=h;b.mappedProperties[e]=!0}})}else switch(e.getType(c)){case "function":v()?d.isWriteableObservable(c)?(c(r(c)),a=c):a=r(c):a=c;break;default:d.isWriteableObservable(a)?v()?a(r(a)):a(d.utils.unwrapObservable(c)):(a=g()?o():d.observable(d.utils.unwrapObservable(c)),v()&&a(r(a)))}return a}function M(a,c,b){for(var d=0,e=a.length;d<
e;d++)if(!0!==b[d]&&a[d]===c)return d;return null}function P(a,c){var b;c&&(b=c(a));"undefined"===e.getType(b)&&(b=a);return d.utils.unwrapObservable(b)}function G(a,c,b){for(var a=d.utils.unwrapObservable(a),f=0,e=a.length;f<e;f++){var g=a[f];if(P(g,b)===c)return g}throw Error("When calling ko.update*, the key '"+c+"' was not found!");}function y(a,c){return d.utils.arrayMap(d.utils.unwrapObservable(a),function(a){return c?P(a,c):a})}function O(a,c){if("array"===e.getType(a))for(var b=0;b<a.length;b++)c(b);
else for(b in a)c(b)}function N(a){var c=e.getType(a);return("object"===c||"array"===c)&&null!==a}function R(){var a=[],c=[];this.save=function(b,f){var e=d.utils.arrayIndexOf(a,b);0<=e?c[e]=f:(a.push(b),c.push(f))};this.get=function(b){b=d.utils.arrayIndexOf(a,b);return 0<=b?c[b]:void 0}}function Q(){var a={},c=function(b){var c;try{c=JSON.stringify(b)}catch(d){c="$$$"}b=a[c];void 0===b&&(b=new R,a[c]=b);return b};this.save=function(a,d){c(a).save(a,d)};this.get=function(a){return c(a).get(a)}}var n=
"__ko_mapping__",I=d.dependentObservable,J=0,D,F,K=["create","update","key","arrayChanged"],t={include:["_destroy"],ignore:[],copy:[]},g=t;e.isMapped=function(a){return(a=d.utils.unwrapObservable(a))&&a[n]};e.fromJS=function(a){if(0==arguments.length)throw Error("When calling ko.fromJS, pass the object you want to convert.");window.setTimeout(function(){J=0},0);J++||(D=[],F=new Q);var c,b;2==arguments.length&&(arguments[1][n]?b=arguments[1]:c=arguments[1]);3==arguments.length&&(c=arguments[1],b=arguments[2]);
b&&(c=A(c,b[n]));c=H(c);var d=B(b,a,c);b&&(d=b);--J||window.setTimeout(function(){for(;D.length;){var a=D.pop();a&&a()}},0);d[n]=A(d[n],c);return d};e.fromJSON=function(a){var c=d.utils.parseJson(a);arguments[0]=c;return e.fromJS.apply(this,arguments)};e.updateFromJS=function(){throw Error("ko.mapping.updateFromJS, use ko.mapping.fromJS instead. Please note that the order of parameters is different!");};e.updateFromJSON=function(){throw Error("ko.mapping.updateFromJSON, use ko.mapping.fromJSON instead. Please note that the order of parameters is different!");
};e.toJS=function(a,c){g||e.resetDefaultOptions();if(0==arguments.length)throw Error("When calling ko.mapping.toJS, pass the object you want to convert.");if("array"!==e.getType(g.ignore))throw Error("ko.mapping.defaultOptions().ignore should be an array.");if("array"!==e.getType(g.include))throw Error("ko.mapping.defaultOptions().include should be an array.");if("array"!==e.getType(g.copy))throw Error("ko.mapping.defaultOptions().copy should be an array.");c=H(c,a[n]);return e.visitModel(a,function(a){return d.utils.unwrapObservable(a)},
c)};e.toJSON=function(a,c){var b=e.toJS(a,c);return d.utils.stringifyJson(b)};e.defaultOptions=function(){if(0<arguments.length)g=arguments[0];else return g};e.resetDefaultOptions=function(){g={include:t.include.slice(0),ignore:t.ignore.slice(0),copy:t.copy.slice(0)}};e.getType=function(a){if(a&&"object"===typeof a){if(a.constructor==(new Date).constructor)return"date";if("[object Array]"===Object.prototype.toString.call(a))return"array"}return typeof a};e.visitModel=function(a,c,b){b=b||{};b.visitedObjects=
b.visitedObjects||new Q;var f,h=d.utils.unwrapObservable(a);if(N(h))b=H(b,h[n]),c(a,b.parentName),f="array"===e.getType(h)?[]:{};else return c(a,b.parentName);b.visitedObjects.save(a,f);var g=b.parentName;O(h,function(a){if(!(b.ignore&&-1!=d.utils.arrayIndexOf(b.ignore,a))){var k=h[a],j=b,o=g||"";"array"===e.getType(h)?g&&(o+="["+a+"]"):(g&&(o+="."),o+=a);j.parentName=o;if(!(-1===d.utils.arrayIndexOf(b.copy,a)&&-1===d.utils.arrayIndexOf(b.include,a)&&h[n]&&h[n].mappedProperties&&!h[n].mappedProperties[a]&&
"array"!==e.getType(h)))switch(e.getType(d.utils.unwrapObservable(k))){case "object":case "array":case "undefined":j=b.visitedObjects.get(k);f[a]="undefined"!==e.getType(j)?j:e.visitModel(k,c,b);break;default:f[a]=c(k,b.parentName)}}});return f}});
