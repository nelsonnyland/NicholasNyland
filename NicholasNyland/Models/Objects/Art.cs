using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NicholasNyland.Models
{
    public class Art
    {
        string Name;
        DateTime Date;
        /// <summary>
        /// 1 = Painting, 2 = Sculpture, 3 = Installation
        /// </summary>
        int Medium;
        string Description;
        string Path;
        
        public Art()
        {
            Name = "";
            Date = new DateTime();
            Medium = 0;
            Description = "";
            Path = "";
        }

        /// <summary>
        /// Instance of Art object.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="date"></param>
        /// <param name="medium">1 = Painting, 
        /// 2 = Sculpture, 3 = Installation</param>
        /// <param name="description"></param>
        /// <param name="path"></param>
        public Art(string name,
                   DateTime date,
                   int medium,
                   string description,
                   string path)
        {
            this.Name = name;
            this.Date = date;
            this.Medium = medium;
            this.Description = description;
            this.Path = path;
        }

        public string GetName()
        {
            return this.Name;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public DateTime GetDate()
        {
            return this.Date;
        }

        public void SetDate(DateTime date)
        {
            this.Date = date;
        }

        /// <summary>
        /// Returns the int corresponding to
        /// 1 = Painting, 2 = Sculpture, 3 = Installation
        /// </summary>
        /// <returns></returns>
        public int GetMedium()
        {
            return this.Medium;
        }

        /// <summary>
        /// Sets medium based on the int corresponding to
        /// 1 = Painting, 2 = Sculpture, 3 = Installation
        /// </summary>
        /// <param name="medium"></param>
        public void SetMedium(int medium)
        {
            this.Medium = medium;
        }

        /// <summary>
        /// Returns the medium name as a string.
        /// </summary>
        /// <returns></returns>
        public string GetNamedMedium()
        {
            if (this.Medium == 1)
            {
                return "Painting";
            } 
            else if (this.Medium == 2)
            {
                return "Sculpture";
            }
            else if (this.Medium == 3)
            {
                return "Installation";
            }
            return null;
        }

        /// <summary>
        /// Sets the medium based on named string argument.
        /// Valid arguments: painting, sculpture, installation.
        /// Returns true if correctly set.
        /// </summary>
        /// <param name="medium"></param>
        /// <returns></returns>
        public bool SetNamedMedium(string medium)
        {
            medium = medium.Trim().ToLower();
            if (medium == "painting")
            {
                this.Medium = 1;
                return true;
            }
            else if (medium == "sculpture")
            {
                this.Medium = 2;
                return true;
            }
            else if (medium == "installation")
            {
                this.Medium = 3;
                return true;
            }            
            return false;
        }

        public string GetDescription()
        {
            return this.Description;
        }

        public void SetDescription(string description)
        {
            this.Description = description;
        }

        public string GetPath()
        {
            return this.Path;
        }

        public void SetPath(string path)
        {
            this.Path = path;
        }

        /// <summary>
        /// Sets path by given file name and type.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileType"></param>
        public void SetPathByName(string fileName, string fileType)
        {
            this.Path = "~/Images/" + fileName + "." + fileType;
        }

        /// <summary>
        /// Compares this Art with the Art given.
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
        public bool Equals(Art piece)
        {
            return this.Name == piece.Name &&
                   this.Date == piece.Date &&
                   this.Medium == piece.Medium;
        }
    }
}