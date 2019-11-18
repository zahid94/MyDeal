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
    public class FirstSliderService : IFirstSliderService
    {
        private readonly IGenericRepository<FirstSlider> repository;
        public FirstSliderService()
        {
            repository = new GenericRepository<FirstSlider>();
        }
        public FirstSlider AddSlider(FirstSlider Slider)
        {
            try
            {
                if (repository.IsExist(x => x.ImageName == Slider.ImageName))
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

        public IEnumerable<FirstSlider> GetAll(Expression<Func<FirstSlider, bool>> expression)
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

        public bool RemoveSlider(FirstSlider Slider)
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

        public FirstSlider SliderDetails(Expression<Func<FirstSlider, bool>> expression)
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

        public bool UpdateSlider(FirstSlider Slider)
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
