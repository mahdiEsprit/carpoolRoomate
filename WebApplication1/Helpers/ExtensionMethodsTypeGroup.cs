using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Helpers
{
    public static class ExtensionMethodsTypeGroup
    {
        public static IEnumerable<SelectListItem> ToSelectListItemsTypeGroup(this IEnumerable<string> GroupeTypes)
        {
            return
                GroupeTypes.OrderBy(types => GroupeTypes)
                      .Select(types =>
                          new SelectListItem
                          {

                              Text = types,
                              Value = types
                          });
        }



    }
}