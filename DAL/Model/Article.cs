
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Model

{
    public class Article
    {
        public Guid Id { get; set; } 

        public string Title { get; set; }
        public string Intro { get; set; }

        public IEnumerable<Block> Blocks { get; set;}

        public Guid AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public virtual IEnumerable<Comment> Comments { get; set;}    

        public virtual DateTime Created { get; set; }
        

        public virtual string ImageName { get; set; }

        public virtual bool Pinned { get; set; }
    }
}
