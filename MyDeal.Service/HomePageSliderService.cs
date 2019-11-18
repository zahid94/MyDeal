using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyDeal.Models;
using MyDeal.Repository;

namespace MyDeal.Service
{
    public class HomePageSliderService : IHomePageSliderService
    {
        private readonly IGenericRepository<HomePageSlider> repository;
        public HomePageSliderService()
        {
            repository = new GenericRepository<HomePageSlider>();
        }

        public HomePageSlider AddSlider(HomePageSlider Slider)
        {
            try
            {
                if (repository.IsExist(x=>x.Name==Slider.Name||x.ImageName==Slider.ImageName))
                {
                    Slider.Id = -1;
                    return Slider;
                }
                else
                {
                    repository.AddEntity(Slider);
                    repository.SaveToDatabase();
                    return Slider;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<HomePageSlider> GetAll(Expression<Func<HomePageSlider, bool>> expression)
        {
            try
            {
                return repository.GetAll(expression);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool RemoveSlider(HomePageSlider Slider)
        {
            try
            {
                repository.RemoveEntity(Slider);
                return repository.SaveToDatabase() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public HomePageSlider SliderDetails(Expression<Func<HomePageSlider, bool>> expression)
        {
            try
            {
                return repository.GetFirstOrDefault(expression);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateSlider(HomePageSlider Slider)
        {
            try
            {
                repository.EditEntity(Slider);
                return repository.SaveToDatabase() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Auto work this method for close all data and other process.
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
