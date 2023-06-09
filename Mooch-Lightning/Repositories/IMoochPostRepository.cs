﻿using Mooch_Lightning.Model;

namespace Mooch_Lightning.Repositories
{
    public interface IMoochPostRepository
    {
        MoochPost Add(MoochPost post);
        void Delete(int id);
        DetailedMoochPostWithSuggetions GetById(int id);
        void Update(MoochPost post, int id);

        List<DetailedMoochPost> GetAll();
        List<MoochPostSearchResult> GetBySearch(string search);
    }
}