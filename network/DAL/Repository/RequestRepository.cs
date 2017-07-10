﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using network.BLL.EF;
using network.DAL.IRepository;

namespace network.DAL.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private NetworkContext context;

        public RequestRepository(NetworkContext context)
        {
            this.context = context;
        }
        

        private bool disposed = false;

        protected virtual void Dispose(bool disposed)
        {
            if (!this.disposed)
            {
                if (disposed)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void NewRequest(Requests request)
        {
            context.Requests.Add(request);
        }

        public Requests SearchById(int id)
        {
            return context.Requests.Find(id);
        }

        public List<Requests> SearchRequests(string id)
        {
            var item = context.Requests.ToList();

            var request = (from req in item.AsEnumerable()
                          where (req.Requesting_user_id == id) && (req.FriendStatuses.Name == "Active")
                                       select req).ToList(); 

            return request;
        }


        public void CancelRequests(Requests request)
        {
            Requests req = context.Requests.Find(request.Id);
            req.FriendStatuses.Name = "Active";
            context.Entry(req).State=EntityState.Modified;

        }

    }
}