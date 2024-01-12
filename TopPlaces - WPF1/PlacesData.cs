﻿using System.Windows.Media.Imaging;

namespace TopPlaces
{
    class PlacesData
    {
        private IList<Place> placesList;

        public PlacesData()
        {
            string pathProject = Environment.CurrentDirectory;
            Place p1 = new Place(pathProject + "/photos/bruxelles.jpg", "Bruxelles");
            Place p2 = new Place(pathProject + "/photos/paris.jpg", "Paris");
            Place p3 = new Place(pathProject + "/photos/moscou.jpg", "Moscou");
            Place p4 = new Place(pathProject + "/photos/amsterdam.jpg", "Amsterdam");
            Place p5 = new Place(pathProject + "/photos/newyork.jpg", "New York");

            placesList = new List<Place>();
            placesList.Add(p1);
            placesList.Add(p2);
            placesList.Add(p3);
            placesList.Add(p4);
            placesList.Add(p5);
        }

        public IList<Place> PlacesList { get { return placesList; } }

    }
    class Place
    {
        string _description;
        string _pathImageFile;
        int _nbVotes;
        Uri _uri;
        BitmapFrame _image;

        public Place(string path, string description)
        {
            _description = description;
            _pathImageFile = path;
            _nbVotes = 0;
            _uri = new Uri(_pathImageFile);
            _image = BitmapFrame.Create(_uri);
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string PathImageFile
        {
            get { return _pathImageFile; }
            set { _pathImageFile = value; }
        }

        public int NbVotes
        {
            get { return _nbVotes; }
            set { _nbVotes = value; }
        }

        public Uri Uri
        {
            get { return _uri; }
            set { _uri = value; }
        }

        public BitmapFrame Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public void Vote()
        {
            _nbVotes++;
        }

    }
}
