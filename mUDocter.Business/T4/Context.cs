

















using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using SubSonic.Linq.Structure;
using SubSonic.Query;
using SubSonic.Schema;
using System.Data.Common;
using System.Collections.Generic;

namespace mUDocter.Business
{
    public partial class MainDB : IQuerySurface
    {

        public IDataProvider DataProvider;
        public DbQueryProvider provider;
        
		private static readonly Object _syncRoot =new Object();
		
		private static volatile MainDB _MainDb;
		
		public static MainDB Instant
		{
			get{
			
				if(_MainDb==null)
				{
					lock(_syncRoot)
					{
						if(_MainDb==null)
						 	_MainDb= new MainDB();
					}
				
				}
				return _MainDb;
				

			}
		}
		
        public bool TestMode
		{
            get
			{
                return DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public MainDB() 
        { 
            DataProvider = ProviderFactory.GetProvider("ConnectionString");
            Init();
        }

        public MainDB(string connectionStringName)
        {
            DataProvider = ProviderFactory.GetProvider(connectionStringName);
            Init();
        }

		public MainDB(string connectionString, string providerName)
        {
            DataProvider = ProviderFactory.GetProvider(connectionString,providerName);
            Init();
        }

		public ITable FindByPrimaryKey(string pkName)
        {
            return DataProvider.Schema.Tables.SingleOrDefault(x => x.PrimaryKey.Name.Equals(pkName, StringComparison.InvariantCultureIgnoreCase));
        }

        public Query<T> GetQuery<T>()
        {
            return new Query<T>(provider);
        }
        
        public ITable FindTable(string tableName)
        {
            return DataProvider.FindTable(tableName);
        }
               
        public IDataProvider Provider
        {
            get { return DataProvider; }
            set {DataProvider=value;}
        }
        
        public DbQueryProvider QueryProvider
        {
            get { return provider; }
        }
        
        BatchQuery _batch = null;
        public void Queue<T>(IQueryable<T> qry)
        {
            if (_batch == null)
                _batch = new BatchQuery(Provider, QueryProvider);
            _batch.Queue(qry);
        }

        public void Queue(ISqlQuery qry)
        {
            if (_batch == null)
                _batch = new BatchQuery(Provider, QueryProvider);
            _batch.Queue(qry);
        }

        public void ExecuteTransaction(IList<DbCommand> commands)
		{
            if(!TestMode)
			{
                using(var connection = commands[0].Connection)
				{
                   if (connection.State == ConnectionState.Closed)
                        connection.Open();
                   
                   using (var trans = connection.BeginTransaction()) 
				   {
                        foreach (var cmd in commands) 
						{
                            cmd.Transaction = trans;
                            cmd.Connection = connection;
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    connection.Close();
                }
            }
        }

        public IDataReader ExecuteBatch()
        {
            if (_batch == null)
                throw new InvalidOperationException("There's nothing in the queue");
            if(!TestMode)
                return _batch.ExecuteReader();
            return null;
        }
			
       // public Query<USER_UD> USER_UDS { get; set; }
       // public Query<PATIENT_UD> PATIENT_UDS { get; set; }
       // public Query<SERVICE_UD> SERVICE_UDS { get; set; }
       // public Query<BOOKING_UD> BOOKING_UDS { get; set; }
       // public Query<DOCTER_IN_SER_UD> DOCTER_IN_SER_UDS { get; set; }
       // public Query<PROVINCE_UD> PROVINCE_UDS { get; set; }
       // public Query<DICTRCT_UD> DICTRCT_UDS { get; set; }
       // public Query<WARDS_UD> WARDS_UDS { get; set; }
       // public Query<DOCTER_UD> DOCTER_UDS { get; set; }

			

        #region ' Aggregates and SubSonic Queries '
        public Select SelectColumns(params string[] columns)
        {
            return new Select(DataProvider, columns);
        }

        public Select Select
        {
            get { return new Select(this.Provider); }
        }

        public Insert Insert
		{
            get { return new Insert(this.Provider); }
        }

        public Update<T> Update<T>() where T:new()
		{
            return new Update<T>(this.Provider);
        }

        public SqlQuery Delete<T>(Expression<Func<T,bool>> column) where T:new()
        {
            LambdaExpression lamda = column;
            SqlQuery result = new Delete<T>(this.Provider);
            result = result.From<T>();
            result.Constraints=lamda.ParseConstraints().ToList();
            return result;
        }

        public SqlQuery Max<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = DataProvider.FindTable(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.Max)).From(tableName);
        }

        public SqlQuery Min<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Min)).From(tableName);
        }

        public SqlQuery Sum<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Sum)).From(tableName);
        }

        public SqlQuery Avg<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Avg)).From(tableName);
        }

        public SqlQuery Count<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Count)).From(tableName);
        }

        public SqlQuery Variance<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Var)).From(tableName);
        }

        public SqlQuery StandardDeviation<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.StDev)).From(tableName);
        }

        #endregion

        void Init()
        {
            provider = new DbQueryProvider(this.Provider);

            #region ' Query Defs '
          //  USER_UDS = new Query<USER_UD>(provider);
          //  PATIENT_UDS = new Query<PATIENT_UD>(provider);
          //  SERVICE_UDS = new Query<SERVICE_UD>(provider);
          //  BOOKING_UDS = new Query<BOOKING_UD>(provider);
          //  DOCTER_IN_SER_UDS = new Query<DOCTER_IN_SER_UD>(provider);
          //  PROVINCE_UDS = new Query<PROVINCE_UD>(provider);
          //  DICTRCT_UDS = new Query<DICTRCT_UD>(provider);
          //  WARDS_UDS = new Query<WARDS_UD>(provider);
          //  DOCTER_UDS = new Query<DOCTER_UD>(provider);
            #endregion


            #region ' Schemas '
        	if(DataProvider.Schema.Tables.Count == 0)
			{
            //	DataProvider.Schema.Tables.Add(new USER_UDTable(DataProvider));
            //	DataProvider.Schema.Tables.Add(new PATIENT_UDTable(DataProvider));
            //	DataProvider.Schema.Tables.Add(new SERVICE_UDTable(DataProvider));
            //	DataProvider.Schema.Tables.Add(new BOOKING_UDTable(DataProvider));
            //	DataProvider.Schema.Tables.Add(new DOCTER_IN_SER_UDTable(DataProvider));
            //	DataProvider.Schema.Tables.Add(new PROVINCE_UDTable(DataProvider));
            //	DataProvider.Schema.Tables.Add(new DICTRCT_UDTable(DataProvider));
            //	DataProvider.Schema.Tables.Add(new WARDS_UDTable(DataProvider));
            //	DataProvider.Schema.Tables.Add(new DOCTER_UDTable(DataProvider));
            }
            #endregion
        }
    }
}