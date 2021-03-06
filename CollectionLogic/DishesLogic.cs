﻿using ISite;
using Maticsoft.Model;
using SiteFactory;
using System.Collections.Generic;

namespace CollectionLogic
{
    public class DishesLogic
    {
        private readonly IDishes _dishesSite;
        public DishesLogic(string assemblyName)
        {
            var collectionFactory = new CollectionFactory(assemblyName);
            _dishesSite = collectionFactory.CreateDishesSecretary();
        }

        public void GetDish(IDishSiteModel dishSiteModel, string storeID)
        {
            _dishesSite.GetDish(dishSiteModel, storeID);
        }

        public void SetPath(string pageUrl)
        {
            _dishesSite.PageUrl = pageUrl;
        }

        public List<IDishSiteModel> DishList
        {
            get { return _dishesSite.DishList; }
            set { _dishesSite.DishList = value; }
        }

        public bool Conversion()
        {
            return _dishesSite.Conversion();
        }

        public List<DishesTyep> GetDish(List<DishesTyep> dishesTyepList)
        {
            return _dishesSite.GetDish(dishesTyepList);
        }
        public void SetLabelEventHandler(IDelegate.LabelEventHandler labelEventHandler)
        {
            _dishesSite.LabelEventHandler += labelEventHandler;
        }
    }
}
