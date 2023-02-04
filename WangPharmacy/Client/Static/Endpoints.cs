using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WangPharmacy.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string AppointmentsEndpoint = $"{Prefix}/appointments";
        public static readonly string CustomersEndpoint = $"{Prefix}/customers";
        public static readonly string MedicinesEndpoint = $"{Prefix}/medicines";
        public static readonly string OrderItemsEndpoint = $"{Prefix}/orderItems";
        public static readonly string OrdersEndpoint = $"{Prefix}/orders";
        public static readonly string PrescriptionItemsEndpoint = $"{Prefix}/prescriptionItems";
        public static readonly string PrescriptionsEndpoint = $"{Prefix}/prescriptions";
        public static readonly string StaffsEndpoint = $"{Prefix}/staffs";
    }
}
