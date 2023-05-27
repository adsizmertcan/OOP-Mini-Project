using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class JobManager : IGenericService<Job>
    {
        IJobDal _jobDal;

        public JobManager(IJobDal jobDal)
        {
            this._jobDal = jobDal;
        }

        public void TAdd(Job t)
        {
            _jobDal.Add(t);
        }

        public void TDelete(Job t)
        {
            _jobDal.Delete(t);
        }

        public Job TGetById(int id)
        {
            return _jobDal.GetById(id);
        }

        public List<Job> TGetList()
        {
            return _jobDal.GetList();
        }

        public void TUpdate(Job t)
        {
            _jobDal.Update(t);
        }
    }
}
