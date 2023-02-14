using LogicLayer.Interface;
using RepositotryLayer.entity;
using RepositotryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.service
{
    public class LableBL: IlableBL
    {
		private readonly IlableRL ilableRL;
		public LableBL(IlableRL ilableRL)
		{
			this.ilableRL = ilableRL;
		}
        public LableEntity AddLable(long userId, string lableName)
        {
			try
			{
				return ilableRL.AddLable(userId, lableName);
			}
			catch (Exception)
			{
				throw;
			}
        }
		public LableEntity EditLable(long userId, long lableId, string newName)
		{
			try
			{
				return ilableRL.EditLable(userId, lableId, newName);
			}
			catch (Exception)
			{

				throw;
			}
		}
		public IEnumerable<LableEntity> ViewLable(long userId)
		{
			try
			{
				return ilableRL.ViewLable(userId);
			}
			catch (Exception)
			{

				throw;
			}
		}
		public bool DeleteLable(long userId, long lableId)
		{
			try
			{
				return ilableRL.DeleteLable(userId, lableId);
			}
			catch (Exception)
			{

				throw;
			}
		}
		public bool AddNoteInLable(long userId, long lableId, long noteId)
		{
			try
			{
				return ilableRL.AddNoteInLable(userId, lableId, noteId);
			}
			catch (Exception)
			{

				throw;
			}
		}
    }
}
