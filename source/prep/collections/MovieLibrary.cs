using System;
using System.Collections.Generic;

namespace prep.collections
{
  public class MovieLibrary
  {
    IList<Movie> movies;

    public MovieLibrary(IList<Movie> list_of_movies)
    {
      this.movies = list_of_movies;
    }

    public IEnumerable<Movie> all_movies()
    {
      return this.movies;
    }

    public void add(Movie movie)
    {
        bool isInList = false;
        foreach (Movie existingMovie in movies)
        {
            if (existingMovie.title == movie.title)
            {
                isInList = true;
            }
        }

        if (!isInList)
        {
            movies.Add(movie);
        }
    }

    public IEnumerable<Movie> sort_all_movies_by_title_descending()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Movie> all_movies_published_by_pixar()
    {
        List<Movie> pixarMovies = new List<Movie>();
        foreach (Movie movie in movies)
        {
            if (movie.production_studio == ProductionStudio.Pixar)
            {
                pixarMovies.Add(movie);
            }
        }
        return pixarMovies;
    }

    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
        List<Movie> pixarDisneyMovies = new List<Movie>();
        foreach (Movie movie in movies)
        {
            if (movie.production_studio == ProductionStudio.Disney)
            {
                pixarDisneyMovies.Add(movie);
            }
        }
        pixarDisneyMovies.AddRange(all_movies_published_by_pixar());

        return pixarDisneyMovies;
    }

    public IEnumerable<Movie> sort_all_movies_by_title_ascending()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
        IList<Movie> nonPixarMovies = new List<Movie>();
        foreach (Movie movie in movies)
        {
            if (movie.production_studio != ProductionStudio.Pixar)
            {
                nonPixarMovies.Add(movie);
            }
        }
        return nonPixarMovies;
    }

    public IEnumerable<Movie> all_movies_published_after(int year)
    {
        IList<Movie> publishafterMovies = new List<Movie>();
        foreach (Movie movie in movies)
        {
            if (movie.date_published.Year > year)
            {
                publishafterMovies.Add(movie);
            }
        }
        return publishafterMovies;
    }

    public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
    {
        IList<Movie> publishbetweenMovies = new List<Movie>();
        foreach (Movie movie in movies)
        {
            if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear)
            {
                publishbetweenMovies.Add(movie);
            }
        }
        return publishbetweenMovies;
    }

    public IEnumerable<Movie> all_kid_movies()
    {
        IList<Movie> kidMovies = new List<Movie>();
        foreach (Movie movie in movies)
        {
            if (movie.genre == Genre.kids)
            {
                kidMovies.Add(movie);
            }
        }
        return kidMovies;
    }

    public IEnumerable<Movie> all_action_movies()
    {
        IList<Movie> actionMovies = new List<Movie>();
        foreach (Movie movie in movies)
        {
            if (movie.genre == Genre.action)
            {
                actionMovies.Add(movie);
            }
        }
        return actionMovies;
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
    {
        throw new NotImplementedException();
    }
  }
}