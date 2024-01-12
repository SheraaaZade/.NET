using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    internal class Actor : Person
    {
        private readonly int _sizeInCentimeter;
        private List<Movie> _movies;

        public int getSizeInCentimeter()
        {
            return _sizeInCentimeter;
        }



        public Actor(string name, string firstname, DateTime birthDate, int sizeInCentimeter) : base(name, firstname, birthDate)
        {
            this._sizeInCentimeter = sizeInCentimeter;
            _movies = new List<Movie>();
        }


        public override string ToString()
        {
            return "Actor [name = " + Name + " firstname = " + Firstname + " sizeInCentimeter = " + _sizeInCentimeter + " birthdate = " + BirthDate + "]";
        }

        /**
         * 
         * @return list of movies in which the actor has played
         */
        public IEnumerator<Movie> Movies()
        {
            return _movies.GetEnumerator();
        }

        /**
         * add movie to the list of movies in which the actor has played
         * @param movie
         * @return false if the movie is null or already present
         */
        public bool addMovie(Movie movie)
        {
            if ((movie == null) || _movies.Contains(movie))
                return false;

            if (!movie.ContainsActor(this))
                movie.AddActor(this);

            _movies.Add(movie);

            return true;
        }

        public bool ContainsMovie(Movie movie)
        {
            return _movies.Contains(movie);
        }

        public override string Name { get { return base.Name.ToUpper(); } }
    }
}
