﻿using NUnit.Framework;
using System.Linq;
using System.Web.Http.Results;
using WebAPI.Controllers;
using WebAPI.Models.Movies;
using WebAPI.Test.TestObjects;

namespace WebAPI.Tests.MovieControllerTests
{
    [TestFixture]
    public class DislikeAMovie
    {
        [Test]
        public void DislikeAMoviesShould_ReturnBadRequest_WhenThereIsNoSuchMovie()
        {
            const string InvalidMessage = "movie";

            var userRepo = TestObjectFactory.GetUserRepository();
            var likesRepo = TestObjectFactory.GetLikesRepository();
            var dislikesRepo = TestObjectFactory.GetDislikesRepository();
            var moviesRepo = TestObjectFactory.GetMovieRepository();
            var moviesLiteRepo = TestObjectFactory.GetMoviesLiteRepository();

            var controller = new MoviesController(moviesRepo, likesRepo, dislikesRepo,
                userRepo, moviesLiteRepo);

            var model = new LikeAMovieModel()
            {
                MovieId = 111,
                Userid = 1
            };

            var result = controller.DislikeAMovie(model);

            var expected = result as BadRequestErrorMessageResult;

            Assert.IsTrue(expected.Message.ToLower().Contains(InvalidMessage));
        }

        [Test]
        public void DislikeAMoviesShould_ReturnBadRequest_WhenThereIsNoSuchUser()
        {
            const string InvalidMessage = "user";

            var userRepo = TestObjectFactory.GetUserRepository();
            var likesRepo = TestObjectFactory.GetLikesRepository();
            var dislikesRepo = TestObjectFactory.GetDislikesRepository();
            var moviesRepo = TestObjectFactory.GetMovieRepository();
            var moviesLiteRepo = TestObjectFactory.GetMoviesLiteRepository();

            var controller = new MoviesController(moviesRepo, likesRepo, dislikesRepo,
                userRepo, moviesLiteRepo);

            var model = new LikeAMovieModel()
            {
                MovieId = 1,
                Userid = 11111
            };

            var result = controller.DislikeAMovie(model);

            var expected = result as BadRequestErrorMessageResult;

            Assert.IsTrue(expected.Message.ToLower().Contains(InvalidMessage));
        }

        [Test]
        public void DislikeAMoviesShould_ReturnOkMessageWIthNumberOFLikesOfTheMovie()
        {
            var userRepo = TestObjectFactory.GetUserRepository();
            var likesRepo = TestObjectFactory.GetLikesRepository();
            var dislikesRepo = TestObjectFactory.GetDislikesRepository();
            var moviesRepo = TestObjectFactory.GetMovieRepository();
            var moviesLiteRepo = TestObjectFactory.GetMoviesLiteRepository();

            var controller = new MoviesController(moviesRepo, likesRepo, dislikesRepo,
                userRepo, moviesLiteRepo);

            var model = new LikeAMovieModel()
            {
                MovieId = 2,
                Userid = 1
            };

            var result = controller.DislikeAMovie(model);

            var expected = result as OkNegotiatedContentResult<int>;


            Assert.IsNotNull(expected);
            Assert.AreEqual(expected.Content, 3);

            var movLiked = moviesRepo.All.Where(x => x.Id == 2).FirstOrDefault();

            Assert.IsTrue(movLiked.DislikesNumber == 3);
        }

        [Test]
        public void DislikeAMoviesShould_CallSaveChanges()
        {
            var userRepo = TestObjectFactory.GetUserRepository();
            var likesRepo = TestObjectFactory.GetLikesRepository();
            var dislikesRepo = TestObjectFactory.GetDislikesRepository();
            var moviesRepo = TestObjectFactory.GetMovieRepository();
            var moviesLiteRepo = TestObjectFactory.GetMoviesLiteRepository();

            var controller = new MoviesController(moviesRepo, likesRepo, dislikesRepo,
                userRepo, moviesLiteRepo);

            var model = new LikeAMovieModel()
            {
                MovieId = 2,
                Userid = 1
            };

            var result = controller.DislikeAMovie(model);

            Assert.AreEqual(1, moviesRepo.NumberOfSavedChanges);
        }

        [Test]
        public void DislikeAMoviesShould_ReturBadRequest_WhenUserAlreadyLikedOrDisliked()
        {
            var AlreadyLikedOrDisliked = "already liked";

            var userRepo = TestObjectFactory.GetUserRepository();
            var likesRepo = TestObjectFactory.GetLikesRepository();
            var dislikesRepo = TestObjectFactory.GetDislikesRepository();
            var moviesRepo = TestObjectFactory.GetMovieRepository();
            var moviesLiteRepo = TestObjectFactory.GetMoviesLiteRepository();

            var controller = new MoviesController(moviesRepo, likesRepo, dislikesRepo,
                userRepo, moviesLiteRepo);

            var model = new LikeAMovieModel()
            {
                MovieId = 2,
                Userid = 1
            };

            var result = controller.DislikeAMovie(model);

            var finalResult = controller.DislikeAMovie(model);

            var final = finalResult as BadRequestErrorMessageResult;

            Assert.IsTrue(final.Message.ToLower().Contains(AlreadyLikedOrDisliked.ToLower()));
        }
    }
}
