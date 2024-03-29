using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using DAL.Repository;
using DAL.IRepository;
using network.Controllers;
using DAL.EF;
using BLL;

namespace network
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            IocExtensions.BindInSingletonScope<NetworkContext>(container);

            container.RegisterType<RepositoryBase>();

            //IocExtensions.BindInSingletonScope<EntityConnection>(container);

            container.BindInRequestScope<IMessageRepository, MessagesRepository>();
            container.BindInRequestScope<IUserRepository, UserRepository>();
            container.BindInRequestScope<IFriendshipRepository, FriendshipRepository>();
            container.BindInRequestScope<IImagesRepository, ImagesRepository>();
            container.BindInRequestScope<IAlbumRepository, AlbumRepository>();
            container.BindInRequestScope<IAlbAndPhotoRepository, AlbAndPhotoRepository>();
            container.BindInRequestScope<IConversationRepository, ConversationRepository>();
            container.BindInRequestScope<ILocationRepository, LocationRepository>();
            container.BindInRequestScope<IParticipantsRepository, ParticipantsRepository>();
            container.BindInRequestScope<IRequestRepository, RequestRepository>();
            container.BindInRequestScope<ISchoolRepository, SchoolRepository>();
            container.BindInRequestScope<IWorkPlaceRepository, WorkPlaceRepository>();


            container.BindInRequestScope<MessagesService>();
            container.BindInRequestScope<UserService>();
            container.BindInRequestScope<FriendshipService>();
            container.BindInRequestScope<ImageService>();
            container.BindInRequestScope<LocationService>();
            container.BindInRequestScope<PhAlbumService>();
            container.BindInRequestScope<SchoolService>();
            container.BindInRequestScope<WorkPlaceService>();


            container.RegisterType<AccountController>(new InjectionConstructor(typeof(UserService)));
            //container.RegisterType<MessagesController>(new InjectionConstructor(typeof(MessagesService),typeof(UserService), typeof(FriendshipService), typeof(ImageService)));

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();     

            return container;
        }
    }
}