using Dapper;
using System.Collections.Generic;
using System.Data;
using XayahFinances.Domain.Entities;
using XayahFinances.Domain.Interfaces.Repositories;

namespace XayahFinances.Infra.Repositories
{
    public class BankAccountRepository : BaseRepository<BankAccount>, IBankAccountRepository
    {
        public BankAccountRepository(IDbConnection connection) : base(connection)
        {
        }

        public override long Create(BankAccount entity)
        {
            var query = @"INSERT INTO bank_accounts 
                            (bank_id, account_number, account_type)
                        OUTPUT INSERTED.ID
                        VALUES
                            (@BankId, @AccountNumber, @AccountType)";

            var id = Connection.QuerySingle<long>(query, entity);
            entity.Id = id;

            return id;
        }

        public override void Delete(long id)
        {
            Connection.Query(@"DELETE FROM bank_accounts WHERE id = @id", new { id = id });
        }

        public override BankAccount Get(long id)
        {
            var query = @"
                SELECT
                    BA.bank_id as BankId,
                    BA.account_number as AccountNumber,
                    BA.account_type as AccountType
                FROM
                    bank_accounts BA
                WHERE BA.id = @id";

            return Connection.QuerySingle<BankAccount>(query, param: new { id = id });
        }

        public override IEnumerable<BankAccount> Get()
        {
            var query = @"
                SELECT
                    BA.bank_id as BankId,
                    BA.account_number as AccountNumber,
                    BA.account_type as AccountType
                FROM
                    bank_accounts BA";

            return Connection.Query<BankAccount>(query);
        }

        public override void Update(BankAccount entity)
        {
            var query = @"
                UPDATE bank_accounts SET
                    bank_id as @BankId,
                    account_number as @AccountNumber,
                    account_type as @AccountType";

            Connection.Query(query);
        }
    }
}
