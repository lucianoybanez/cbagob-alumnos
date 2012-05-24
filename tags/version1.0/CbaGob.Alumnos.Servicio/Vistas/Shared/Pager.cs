using System;

namespace CbaGob.Alumnos.Servicio.Vistas.Shared
{
    public interface IPager
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        int TotalCount { get; set; }
        int TotalPages { get; set; }
        int Skip { get; set; }
        string ActionName { get; set; }
        string FormName { get; set; }
        bool IsPreviousPage { get; }
        bool IsNextPage { get; }

    }

    [Serializable]
    public class Pager : IPager
    {
        private int totalCount;
        private int pageNumber;
        private int pageSize;

        public Pager()
        {
            
        }

        public Pager(int totalCount, string formName,string actionToGo)
        {
            this.TotalCount = totalCount;
            this.FormName = formName;
            this.ActionName = actionToGo;
        }

        public Pager(int totalCount, int pageSize, string formName, string actionToGo)
        {
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
            this.FormName = formName;
            this.ActionName = actionToGo;
        }

        public int PageSize
        {
            get
            {
                if (pageSize==0)
                {
                   try
                    {
                        pageSize = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("PageCount"));
                        if (pageSize==0)
                        {
                            pageSize = 10;
                        }
                    }
                    catch 
                    {
                        pageSize = 10;
                    }

                    
                }
                return pageSize;
            }
            set { pageSize = value; }
        }
        public int PageNumber
        {
            get
            {
                if (pageNumber==0)
                {
                    pageNumber = 1;
                }
                return pageNumber;
            }
            set
            {
                if (value == 0)
                {
                    pageNumber = 1;
                }
                else
                {
                    pageNumber = value;
                }
                Skip = (pageNumber - 1) * PageSize;
            }
        }

        public int TotalCount
        {
            get { return totalCount; }
            set
            {
                totalCount = value;
                TotalPages = setPages(TotalCount, PageSize);
            }
        }
        public int TotalPages { get; set; }
        public int Skip { get; set; }
        public string ActionName { get; set; }
        public string FormName { get; set; }
        public bool IsPreviousPage
        {
            get { return (pageNumber > 1); }
        }

        public bool IsNextPage
        {
            get { return pageNumber < TotalPages; }
        }

        private static int setPages(int p_Rows, int p_PageSize)
        {
            int ret;
            try
            {
                ret = Convert.ToInt32(Math.Ceiling((decimal)p_Rows / p_PageSize));
            }
            catch (Exception ex)
            {
                throw new Exception("setPages() error: " + ex.Message);
            }
            return ret;
        }
    }
}
