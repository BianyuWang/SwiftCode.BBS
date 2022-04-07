using System;
using SwiftCode.BBS.IRepositories;
namespace Repositories
{
    public class CalculateRepository : ICalculateRepository
    {
        public int Sum(int i, int j)
        {
            return i + j;
        }
    }
}
