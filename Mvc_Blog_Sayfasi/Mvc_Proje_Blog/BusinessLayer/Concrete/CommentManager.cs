using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class CommentManager
    {

        Repository<Comment> repoComment = new Repository<Comment>();
        public List<Comment> CommentList()// tüm yorumlar listeleniyor.
        {
            return repoComment.List();
        }
        public List<Comment> CommentByBlog(int id)//bloğa göre yorumlar listeleniyor.
        {
            return repoComment.List(x=>x.BlogID==id);
        }
        public List<Comment> CommentByStatusTrue()//bloğa göre true olan yorumlar listeleniyor.
        {
            return repoComment.List(x => x.CommentStatus==true);
        }
        public List<Comment> CommentByStatusFalse()//bloğa göre true olan yorumlar listeleniyor.
        {
            return repoComment.List(x => x.CommentStatus == false);
        }
        public int CommentAdd(Comment c)
        {
            if(c.CommentText.Length<=4 || c.CommentText.Length>=301 || c.UserName=="" || c.Mail=="" || c.UserName.Length<=2)
            
            {
                return -1;
            }
            return repoComment.Insert(c);
        }
        public int CommentStatusChangeToFalse(int id)
        {
            Comment comment = repoComment.Find(x=>x.CommentId==id);
            comment.CommentStatus = false;
            return repoComment.Update(comment);

        }
        public int CommentStatusChangeToTrue(int id)
        {
            Comment comment = repoComment.Find(x => x.CommentId == id);
            comment.CommentStatus = true;
            return repoComment.Update(comment);

        }


    }
}
