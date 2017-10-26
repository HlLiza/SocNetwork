﻿using System;
using System.Data.Entity;
using System.Linq;
using network.BLL.EF;
using network.DAL.Enums;
using network.DAL.IRepository;

namespace network.DAL.Repository
{
    public class RequestRepository : RepositoryBase,IRequestRepository
    {

        public RequestRepository() 
        {
        }

        public RequestRepository(NetworkContext cont):base(cont)
        {
        }
        

        public void AddRequest(Requests request)
        {
            _context.Requests.Add(request);
            base.Save();
        }

        public void CancelRequests(Requests request)
        {
            if (request == null)
            {
                request.FriendStatuses.Name = "Active";
                _context.Entry(request).State = EntityState.Modified;
            }
            base.Save();
        }

        public void Update(Requests requests)
        {
            _context.Entry(requests).CurrentValues.SetValues(requests);
            base.Save();
        }

        public Requests SearchById(int id)
        {
            return _context.Requests.Find(id);
        }
        
        public Requests SearchByUsersId(string idIng, string idEd)
        {
            return _context.Requests.FirstOrDefault(s => s.Requesting_user_id == idIng && s.Requested_user_id == idEd);
        }
        

        //return active list of requests 
        public IQueryable<Requests> GetActiveRequests(string id)
        {
            return _context.Requests.Where(s => s.Requesting_user_id == id && s.Status_id == 1);
           
        }


        //return active request for sertains users
        public Requests CheckRequests(string idEd, string idIng)
        {
            return _context.Requests.FirstOrDefault(s => s.Requested_user_id == idEd && s.Requesting_user_id == idIng && s.Status_id==(int)FriendshipStatus.Active);
        }


        //change status of request      
        public void EditStatusOfRequest(int id, FriendshipStatus active)
        {
            var req = SearchById(id);
            req.Status_id = Convert.ToInt32(active);
            _context.Entry(req).CurrentValues.SetValues(req);
            base.Save();
        }
    }
}