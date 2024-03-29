﻿namespace Shopping_Store_API.Commons
{
    public abstract class QueryStringParameters
    {
        const int maxPageSize = 50;
        public int pageNumber { get; set; } = 1;

        private int _pageSize = 12;
        public int pageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
