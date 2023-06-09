﻿using Mooch_Lightning.Model;

namespace Mooch_Lightning.Repositories
{
    public interface IMoochRequestRepository
    {
        MoochRequest GetMoochRequestById(int id);
        List<MoochRequest> TopFiveApprovedMoochRequests();
        List<MoochRequest> TopFivePendingMoochRequests();

        void Add(MoochRequest moochRequest);
    }
}