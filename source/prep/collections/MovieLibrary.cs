using System;
using System.Collections.Generic;
using prep.utility;

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
      return movies.one_at_a_time();
    }

    public void add(Movie movie)
    {
      if (already_contains(movie)) return;

      movies.Add(movie);
    }

    bool already_contains(Movie movie)
    {
      return movies.Contains(movie);
    }

    public IEnumerable<Movie> all_movies_matching(Condition<Movie> condition)
    {
      return movies.all_items_matching(condition);
    }

    public IEnumerable<Movie> all_movies_published_by_pixar()
    {
      return all_movies_matching(x => x.production_studio == ProductionStudio.Pixar);
    }

    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
      return
        all_movies_matching(
          x => x.production_studio == ProductionStudio.Pixar || x.production_studio == ProductionStudio.Disney);
    }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
      IList<Movie> nonPixarMovies = new List<Movie>();
      foreach (var movie in movies)
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
      foreach (var movie in movies)
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
      foreach (var movie in movies)
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
      foreach (var movie in movies)
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
      foreach (var movie in movies)
      {
        if (movie.genre == Genre.action)
        {
          actionMovies.Add(movie);
        }
      }
      return actionMovies;
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_title_ascending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_title_descending()
    {
      throw new NotImplementedException();
    }
  }
}