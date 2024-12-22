using KT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KT.Controllers
{
    public class HocPhansController : Controller
    {
        private readonly Test1Context _context;

        public HocPhansController(Test1Context context)
        {
            _context = context;
        }

        // GET: HocPhans
        public async Task<IActionResult> Index()
        {
            return View(await _context.HocPhans.ToListAsync());
        }

        // Đăng Ký Học Phần
        [HttpPost]
        public async Task<IActionResult> Register(string maHP)
        {
            var maSV = User.Identity.Name; // Lấy MaSV của người đăng nhập

            var sinhVien = await _context.SinhViens.FirstOrDefaultAsync(sv => sv.MaSv == maSV);
            if (sinhVien == null)
            {
                return NotFound("Sinh viên không tồn tại.");
            }

            var dangKy = await _context.DangKies.FirstOrDefaultAsync(dk => dk.MaSv == maSV);
            if (dangKy == null)
            {
                dangKy = new DangKy
                {
                    MaSv = maSV,
                    NgayDk = DateOnly.FromDateTime(DateTime.Now)
                };
                _context.DangKies.Add(dangKy);
                await _context.SaveChangesAsync();
            }

            // Kiểm tra nếu ChiTietDangKy đã tồn tại
            var chiTietDangKy = await _context.ChiTietDangKies
                .FirstOrDefaultAsync(ctdk => ctdk.MaDk == dangKy.MaDk && ctdk.MaHp == maHP);
            if (chiTietDangKy == null)
            {
                chiTietDangKy = new ChiTietDangKy
                {
                    MaDk = dangKy.MaDk,
                    MaHp = maHP
                };

                _context.ChiTietDangKies.Add(chiTietDangKy);
                await _context.SaveChangesAsync();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Học phần này đã được đăng ký.");
            }

            return RedirectToAction("Index", "DangKies"); // Chuyển hướng đến trang DangKies
        }

        // GET: HocPhans/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocPhan = await _context.HocPhans
                .FirstOrDefaultAsync(m => m.MaHp == id);
            if (hocPhan == null)
            {
                return NotFound();
            }

            return View(hocPhan);
        }

        // GET: HocPhans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HocPhans/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHp,TenHp,SoTinChi")] HocPhan hocPhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hocPhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hocPhan);
        }

        // GET: HocPhans/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocPhan = await _context.HocPhans.FindAsync(id);
            if (hocPhan == null)
            {
                return NotFound();
            }
            return View(hocPhan);
        }

        // POST: HocPhans/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHp,TenHp,SoTinChi")] HocPhan hocPhan)
        {
            if (id != hocPhan.MaHp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hocPhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HocPhanExists(hocPhan.MaHp))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hocPhan);
        }

        // GET: HocPhans/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocPhan = await _context.HocPhans
                .FirstOrDefaultAsync(m => m.MaHp == id);
            if (hocPhan == null)
            {
                return NotFound();
            }

            return View(hocPhan);
        }

        // POST: HocPhans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hocPhan = await _context.HocPhans.FindAsync(id);
            if (hocPhan != null)
            {
                _context.HocPhans.Remove(hocPhan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HocPhanExists(string id)
        {
            return _context.HocPhans.Any(e => e.MaHp == id);
        }
    }
}
