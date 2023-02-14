using LogicLayer.Interface;
using Microsoft.IdentityModel.Tokens;
using RepositotryLayer.entity;
using RepositotryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.service
{
    public class CollabBL: IcollabBL
    {

		private readonly IcollabRL icollabRL;

		public CollabBL(IcollabRL icollabRL)
		{
			this.icollabRL = icollabRL;
		}

        public CollabEntity AddCollaborator(string collabEmail, long noteId, long userId)
        {
			try
			{
				return this.icollabRL.AddCollaborator(collabEmail, noteId,userId);
			}
			catch (Exception e)
			{

				throw e;
			}
        }

		public IEnumerable<CollabEntity> ViewCollaborator(long userId, long noteId)
		{
			try
			{
				return icollabRL.ViewCollaborator(userId, noteId);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public bool RemoveCollaborator(string collabEmail, long userId, long noteId)
		{
			try
			{
				return icollabRL.RemoveCollaborator(collabEmail, userId, noteId);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
