using log4net;
using System;
using System.Reflection;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Publishing;
using Umbraco.Core.Services;

namespace PurityBridge.Umbraco.Events
{
    public class UmbracoApplicationEventHandler : ApplicationEventHandler
    {
        private int SiteStructureId = 0;
        private int SiteDataId = 0;

        public static readonly ILog Log =
            LogManager.GetLogger(
                MethodBase.GetCurrentMethod().DeclaringType
            );

        protected static void LogValidationError(IContent content)
        {
            Log.Error(string.Format("Validation Failed for Node {0} [{1}].", content.Name, content.ContentType.Alias));
        }

        protected static void LogNodeCreationInfo(IContent content)
        {
            var parentName = (content.Parent() != null ? content.Parent().ContentType.Name : "<root-node>");
            var parentAlias = (content.Parent() != null ? content.Parent().ContentType.Alias : "<root>");
            Log.Info(string.Format("Created node {0} [{1}] under {2} [{3}]", content.Name, content.ContentType.Alias, parentName, parentAlias));
        }

        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            Log.Info(string.Format("Umbraco is starting."));
            base.ApplicationStarting(umbracoApplication, applicationContext);
        }

        protected override void ApplicationStarted(
            UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            Log.Info(string.Format("Umbraco is running on {0}.", Environment.MachineName));
            ContentService.Copied += ContentService_Copied;
            ContentService.Moved += ContentService_Moved;
            ContentService.Deleted += ContentService_Deleted;
            ContentService.Published += ContentService_Published;
            ContentService.UnPublished += ContentService_UnPublished;
            ContentService.Saved += ContentService_Saved;
            ContentService.Saving += ContentService_Saving;
            Log.Info(string.Format("Application Events are registered."));
        }

        void ContentService_Saving(IContentService sender, SaveEventArgs<IContent> e)
        {
            IContent contentItem = null;
            e.SavedEntities.ForEach(content =>
            {
                if (content.IsValid())
                {
                    contentItem = content.Ancestors().FirstOrDefault(a => a.ContentType.Alias == "ContentItem");
                    if(contentItem != null && (SiteStructureId != contentItem.Id))
                    {
                        SiteStructureId = contentItem.Id;
                    }
                    if (content.HasIdentity)
                    {
                        
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (e.CanCancel)
                    {
                        e.Cancel = true;
                    }
                }
            });
        }

        private void IntitializeMembers(IContentService sender, )
        {
            if (SiteStructure == null)
            {

            }
        }

        void ContentService_Saved(IContentService sender, SaveEventArgs<IContent> e)
        {
            string parentName = null;
            string parentAlias = null;
            e.SavedEntities.ForEach(content =>
            {
                parentName = (content.Parent() != null ? content.Parent().ContentType.Name : "<root-node>");
                parentAlias = (content.Parent() != null ? content.Parent().ContentType.Alias : "<root>");

                if (content.IsNewEntity())
                {
                    Log.Info(string.Format("Created node {0} [{1}] under {2} [{3}]", content.Name, content.ContentType.Alias, parentName, parentAlias));
                }
                else
                {
                    Log.Info(string.Format("Updated node {0} [{1}] under {2} [{3}]", content.Name, content.ContentType.Alias, parentName, parentAlias));
                }
                if (content.ContentType.Alias == "ContentItem")
                {
                    if (content.IsNewEntity())
                    {

                    }
                    else
                    {

                    }
                }
                else if (content.ContentType.Alias == "PageData")
                {
                    if (content.HasIdentity)
                    {

                    }
                    else
                    {

                    }
                }
                else
                {
                    if (content.HasIdentity)
                    {

                    }
                    else
                    {

                    }
                }
            });
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