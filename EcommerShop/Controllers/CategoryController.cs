using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerShop.Models.ModelBusiness;
using EcommerShop.Models.ModelViews.Category;
namespace EcommerShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ECommerceStoreContext _context;
        public CategoryController(ECommerceStoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var mockupDatas = new List<object>()
            {
               new { Id=1 , Name="Claude1"},
               new { Id=2 , Name="Claude2"},
               new { Id=3 , Name="Claude3"},
               new { Id=4 , Name="Claude4"},
               new { Id=5 , Name="Claude5"},
               new { Id=6 , Name="Claude6"},
               new { Id=7 , Name="Claude7"},
               new { Id=8 , Name="Claude8"},
               new { Id=9 , Name="Claude9"},
               new { Id=10 , Name="Claude10"},
               new { Id=11 , Name="Claude11"},
               new { Id=12 , Name="Claude12"},
               new { Id=13 , Name="Claude13"},
               new { Id=14 , Name="Claude14"},
               new { Id=15 , Name="Claude15"},
               new { Id=16 , Name="Claude16"},
               new { Id=17 , Name="Claude17"}
            };
            return Json(await _context.AttributeSet.ToListAsync());
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddModelView data)
        {
            if (data != null && !string.IsNullOrEmpty(data.Name))
            {

                AttributeSet attSet = new AttributeSet
                {
                    Name = data.Name
                };
                foreach (EcommerShop.Models.ModelBusiness.Attribute att in data.Attributes)
                {
                    if (string.IsNullOrEmpty(att.Name) || string.IsNullOrEmpty(att.Code))
                        continue;
                    attSet.JointAttributeSet.Add(new JointAttributeSet
                    {
                        AttributeSetId = attSet.Id,
                        AttributeId = att.Id,
                        Attribute = att,
                        AttributeSet = attSet
                    });
                }
                using (var transaction = _context.Database.BeginTransaction())
                {

                    try
                    {
                        _context.Add(attSet);
                        _context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error occurred.");
                        return Json(new
                        {
                            statusCode = 500,
                            msg = "Server đã xảy ra lỗi vui lòng quay lại sau!"
                        });
                    };
                }
                return Json(new
                {
                    statusCode = 200,
                    msg = "Bạn đã thêm danh mục " + attSet.Name + "  với " + attSet.JointAttributeSet.Count + " thuộc tính!"
                });
            }
            return Json(new
            {
                statusCode = 400,
                msg = "Tên danh mục hoặc thuộc tính danh mục chưa điền!"
            });
        }

        [HttpGet]
        public IActionResult Detail(int? id)
        {
            if (id == null) id = 0;
            var entireSet = _context.AttributeSet.Where(attSet => attSet.Id == id)
                                             .Include("JointAttributeSet.Attribute")
                                             .FirstOrDefault();
            if (entireSet != null)
            {
                return Json(new
                {
                    httpStatus = 200,
                    msg = "",
                    data = entireSet
                });
            }

            return Json(new
            {
                httpStatus = 404,
                msg = "Không tìm thấy danh mục này!"
            });

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            AttributeSet attSet = _context.AttributeSet.Where(ast => ast.Id == id)
                                                        .Include("JointAttributeSet.Attribute")
                                                        .Include("Product")
                                                        .FirstOrDefault();
            int httpStatus = 404;
            string msg = "Không tìm thấy danh mục bạn yêu cầu!";
            if (attSet != null)
            {
                if (attSet.Product.Count > 0)
                {
                    httpStatus = 403;
                    msg = "Đang có nhiều sản phẩm thuộc danh mục này, bạn không thể xóa, vui lòng sử dụng chỉnh sửa!";

                }
                else
                {
                   foreach(var jointSet in attSet.JointAttributeSet) {
                        _context.Attribute.Remove(jointSet.Attribute);
                        _context.JointAttributeSet.Remove(jointSet);
                    }
                    _context.SaveChanges();
                    _context.AttributeSet.Remove(attSet);
                    _context.SaveChanges();
                    //_context.AttributeSet.Remove(attSet);
                    //_context.SaveChanges();
                    httpStatus = 200;
                    msg = "Danh mục " + attSet.Name + " đã được xóa thành công!";
                }
            }
            return Json(new
            {
                httpStatus = httpStatus,
                msg = msg
            });

        }
    }
}