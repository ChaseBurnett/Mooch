﻿using Mooch_Lightning.Model;

namespace Mooch_Lightning.Repositories
{
    public interface IUserRepository
    {
        User GetById(int id);
    }
}