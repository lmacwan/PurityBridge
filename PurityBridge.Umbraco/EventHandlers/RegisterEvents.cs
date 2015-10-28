using Umbraco.Core;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Publishing;
using Umbraco.Core.Services;

namespace PurityBridge.Umbraco
{
    public class MyEventHandler : ApplicationEventHandler
    {

        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            ContentService.Copied += ContentService_Copied;
            ContentService.Moved += ContentService_Moved;
            ContentService.Deleted += ContentService_Deleted;
            ContentService.Published += ContentService_Published;
            ContentService.UnPublished += ContentService_UnPublished;
            ContentService.Saved += ContentService_Saved;
            ContentService.Saving += ContentService_Saving;
        }

        void ContentService_Saving(IContentService sender, SaveEventArgs<IContent> e)
        {
        }

        void ContentService_Saved(IContentService sender, SaveEventArgs<IContent> e)
        {
            throw new System.NotImplementedException();
        }

        void ContentService_UnPublished(IPublishingStrategy sender, PublishEventArgs<IContent> e)
        {
            throw new System.NotImplementedException();
        }

        void ContentService_Published(IPublishingStrategy sender, PublishEventArgs<IContent> e)
        {
            throw new System.NotImplementedException();
        }

        void ContentService_Deleted(IContentService sender, DeleteEventArgs<IContent> e)
        {
            throw new System.NotImplementedException();
        }

        void ContentService_Moved(IContentService sender, MoveEventArgs<IContent> e)
        {
            throw new System.NotImplementedException();
        }

        void ContentService_Copied(IContentService sender, CopyEventArgs<IContent> e)
        {
            throw new System.NotImplementedException();
        }

        void ContentService_Created(IContentService sender, NewEventArgs<IContent> e)
        {
            throw new System.NotImplementedException();
        }
    }
}