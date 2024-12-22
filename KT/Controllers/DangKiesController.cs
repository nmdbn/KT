//using Microsoft.AspNetCore.Mvc;
//using KT.Models;
//using System.Linq;

//public class DangKiesController : Controller
//{
//    private readonly Test1Context _context;

//    public DangKiesController(Test1Context context)
//    {
//        _context = context;
//    }

//    public IActionResult Index()
//    {
//        var maSV = User.Identity.Name;
//        var registeredCourses = _context.DangKies
//            .Where(d => d.MaSv == maSV)
//            .SelectMany(d => d.ChiTietDangKies, (d, ctdk) => new
//            {
//                ctdk.MaHp,
//                ctdk.HocPhan.TenHp,
//                ctdk.HocPhan.SoTinChi
//            })
//            .ToList();

//        return View(registeredCourses);
//    }

//    [HttpPost]
//    public IActionResult Delete(string maHP)
//    {
//        var maSV = User.Identity.Name;
//        var registration = _context.DangKies.FirstOrDefault(d => d.MaSv == maSV);
//        if (registration != null)
//        {
//            var course = _context.ChiTietDangKies.FirstOrDefault(c => c.MaDk == registration.MaDk && c.MaHp == maHP);
//            if (course != null)
//            {
//                _context.ChiTietDangKies.Remove(course);
//                _context.SaveChanges();
//            }
//        }
//        return RedirectToAction("Index");
//    }

//    [HttpPost]
//    public IActionResult DeleteAll()
//    {
//        var maSV = User.Identity.Name;
//        var registrations = _context.DangKies.Where(d => d.MaSv == maSV).ToList();
//        foreach (var registration in registrations)
//        {
//            var courses = _context.ChiTietDangKies.Where(c => c.MaDk == registration.MaDk).ToList();
//            _context.ChiTietDangKies.RemoveRange(courses);
//        }
//        _context.SaveChanges();

//        return RedirectToAction("Index");
//    }
//}

using Microsoft.AspNetCore.Mvc;
using KT.Models;
using System.Linq;

public class DangKiesController : Controller
{
    private readonly Test1Context _context;

    public DangKiesController(Test1Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var maSV = User.Identity.Name;
        var registeredCourses = _context.DangKies
            .Where(d => d.MaSv == maSV)
            .SelectMany(d => d.ChiTietDangKies, (d, ctdk) => new
            {
                ctdk.MaHp,
                ctdk.HocPhan.TenHp,
                ctdk.HocPhan.SoTinChi
            })
            .ToList();

        return View(registeredCourses);
    }

    [HttpPost]
    public IActionResult Delete(string maHP)
    {
        var maSV = User.Identity.Name;
        var registration = _context.DangKies.FirstOrDefault(d => d.MaSv == maSV);
        if (registration != null)
        {
            var course = _context.ChiTietDangKies.FirstOrDefault(c => c.MaDk == registration.MaDk && c.MaHp == maHP);
            if (course != null)
            {
                _context.ChiTietDangKies.Remove(course);
                _context.SaveChanges();
            }
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteAll()
    {
        var maSV = User.Identity.Name;
        var registrations = _context.DangKies.Where(d => d.MaSv == maSV).ToList();
        foreach (var registration in registrations)
        {
            var courses = _context.ChiTietDangKies.Where(c => c.MaDk == registration.MaDk).ToList();
            _context.ChiTietDangKies.RemoveRange(courses);
        }
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Save()
    {
        // Thực hiện các bước lưu nếu cần thiết
        return RedirectToAction("Index");
    }
}
