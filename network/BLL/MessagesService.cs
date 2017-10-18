﻿using System.Collections.Generic;
using System.Linq;
using network.BLL.EF;
using network.DAL.IRepository;
using network.DAL.Repository;
using network.Views.ViewModels;

namespace network.BLL
{
    public class MessagesService
    {
        private readonly IParticipantsRepository _participantsRepository;
        private readonly IConversationRepository _conversationRepository;
        private readonly IFriendshipRepository _friendshipRepository;
        private readonly IUserRepository _userRepository;
        private readonly IImagesRepository _imgRepository;

        public MessagesService()
        {
        }

        public MessagesService(ParticipantsRepository participantsRepository, ConversationRepository conversationRepository, 
            FriendshipRepository friendshipRepository, UserRepository userRepository, ImagesRepository imgRepository)
        {
            _participantsRepository = participantsRepository;
            _conversationRepository = conversationRepository;
            _friendshipRepository = friendshipRepository;
            _userRepository = userRepository;
            _imgRepository = imgRepository ;
        }


        //get all friends
        public IQueryable<Friendship> GetFriendForSelect(string id)
        {
            return _friendshipRepository.GetListFriends(id);
        }

        //get list of friend's Ids without existing conversations
        public List<int> GetFriendsIdsList(int id)
        {
            List<int> friendsIds=new List<int>();

            var conversationIdsList = _conversationRepository.GetConversationsIdsByCreatorId(id);
            if(conversationIdsList!=null)
                friendsIds = _conversationRepository.GetFriendsIdsList(conversationIdsList);
            return friendsIds;
        }

        
        //get  information for friends
        public List<ConversationViewModel> GetUserDetails(List<UserDetails> userList)
        {
            List<ConversationViewModel> detailsList= new List<ConversationViewModel>();

            foreach (var item in userList)
            {
                ConversationViewModel user =new ConversationViewModel();
                var userDetails= _userRepository.GetUserById(item.Id);
                var image = _imgRepository.GetImageById(userDetails.ImagesId);
                
                    user.Id = userDetails.Id;
                    user.Name = userDetails.Name;
                    user.FirstName = userDetails.Firstname;
                    user.Image = image.Data;
                    detailsList.Add(user);
            }
            return detailsList.ToList();
        }
        

        //translate Id-string -> Id-int
        public int GetIntId(string id)
        {
            return _userRepository.ReturnIntId(id);
        }

        

        //  CONVERSATION
        public void CreateConversation(Conversation conversation)
        {
            if (conversation != null)
            {
                _conversationRepository.AddConversations(conversation);
               
            }
        }


        //позволяет получить список id друзей, с которыми существует Conversation
        public List<int> GetFriendsIdListFromConversation(int id)
        {
            List<int> friendsIds=new List<int>();

            var conversationsIds = _conversationRepository.GetConversationsIdsByCreatorId(id);
            if (conversationsIds != null)
            {
               friendsIds = _conversationRepository.GetFriendsIdsList(conversationsIds);
            }
            return friendsIds;
        }


        //PARTICIPANTS

        public void CreateParticipants(Participants participants)
       {
            if (participants != null)
            {
                _participantsRepository.AddParticipants(participants);
            }
            
        }

    }
}