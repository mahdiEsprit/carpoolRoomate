using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Helpers
{

    public static class ExtensionMethods
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(
              this IEnumerable<string> Regions)
        {
            return
                Regions.OrderBy(genre => Regions)
                      .Select(genre =>
                          new SelectListItem
                          {

                              Text = genre,
                              Value = genre
                          });
        }
    }
}