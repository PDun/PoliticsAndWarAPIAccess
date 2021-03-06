﻿using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PoliticsAndWarAPIAccess.API.Models;

namespace PoliticsAndWarAPIAccess.API.Interfaces
{
  public interface IWarAttackAPI
  {
    Task<WarAttackResponse> GetWarAttack(string key, int warId = 0, int minWarAttackId = 0, int maxWarAttackId = 0, Expression<Func<WarAttack, bool>> expression = null, bool UseCache = true);
  }
}