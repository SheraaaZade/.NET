using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Movie
    {
        private string _title;
        private int _releaseYear;
        private List<Actor> _actors;
        private Director? _director = null;

        public Movie(string title, int releaseYear)
        {
            _actors = new List<Actor>();
            this._title = title;
            this._releaseYear = releaseYear;
        }

        public Director? Director
        {
            get { return _director; }
            set
            {
                if (value == null) return;
                this._director = value;
                _director?.AddMovie(this);
            }
        }

        public string Title { get { return _title; } set { _title = value; } }
 
        public int ReleaseYear
        {
            get { return _releaseYear; }
            set { _releaseYear = value; }
        }

        public bool AddActor(Actor actor)
        {
            if (_actors.Contains(actor))
                return false;

            _actors.Add(actor);
            if (!actor.ContainsMovie(this))
                actor.addMovie(this);

            return true;
        }

        public bool ContainsActor(Actor actor)
        {
            return _actors.Contains(actor);
        }

        public String toString()
        {
            return "Movie [title=" + _title + ", releaseYear=" + _releaseYear + "]";
        }

    }
}
