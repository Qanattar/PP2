using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
      
            public class Post
        {
            
            public string author;
            public string date;
            public string text;
            public Post()
            {

            }
            public void PrintInfo()
            {
                Console.WriteLine(string.Format("{0} {1} {2}", author, date, text));
            }
        }

    public class Author
    {
      
        public string name;
        public string surname;
        public string age;

        public Author()
        {

        }

        public void PrintInfo1()
        {
            Console.WriteLine(string.Format("{0} {1} {2}", name,surname,age));
        }

        
    }

    class Program
        {
            static void Main(string[] args)
            {
            Post post = new Post();
            post.author = "Me";
            post.date = "05.0.6.2019";
            post.text = "hard";
            XmlSerializer xs = new XmlSerializer(typeof(Post));

            FileStream fs = new FileStream("post.txt", FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, post);
            fs.Close();



            FileStream fs1 = new FileStream("post.txt", FileMode.Open, FileAccess.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Post));
            post = xmlSerializer.Deserialize(fs1) as Post;
            post.PrintInfo();
            fs1.Close();




            Author author = new Author();
            author.name = "Kanat";
            author.surname = "Koptileuov";
            author.age = "19";
            XmlSerializer xs1 = new XmlSerializer(typeof(Author));

            FileStream fs2 = new FileStream("author.txt", FileMode.Create, FileAccess.Write);
            xs1.Serialize(fs2, author);
            fs2.Close();



            FileStream fs3 = new FileStream("author.txt", FileMode.Open, FileAccess.Read);
            XmlSerializer xmlSerializer1 = new XmlSerializer(typeof(Author));
            author = xmlSerializer1.Deserialize(fs3) as Author;
            author.PrintInfo1();
            fs3.Close();
        }
    }

            
           
    }
    

