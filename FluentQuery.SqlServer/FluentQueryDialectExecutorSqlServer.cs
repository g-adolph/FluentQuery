﻿using FluentQuery.Core.Dialects.Base;

namespace FluentQuery.SqlServer
{
    public class FluentQueryDialectExecutorSqlServer : IFluentQueryDialectFullExecutor
    {
        public TResult Execute<TResult>()
        {
            throw new System.NotImplementedException();
        }

        public TResult Execute<TResult, TDataFilter>(TDataFilter dataProcess)
        {
            throw new System.NotImplementedException();
        }

        public TResult ExecuteAsync<TResult>()
        {
            throw new System.NotImplementedException();
        }

        public TResult ExecuteAsync<TResult, TDataFilter>(TDataFilter dataProcess)
        {
            throw new System.NotImplementedException();
        }
    }
}