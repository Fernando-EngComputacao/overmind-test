﻿using Teste.Models;
using Teste.Models.Device;

namespace Teste.Client.Interfaces;

public interface IClientDevices
{
    Task<List<Device>> GetDeviceList();
    Task<List<Apple>> GetAppleList();
}