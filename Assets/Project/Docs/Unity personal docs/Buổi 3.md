# 1. Properties
- Là cơ chế để bảo vệ dữ liệu thông qua `get` và `set`. Giúp kiểm soát ai là người xem và thay đổi dữ liệu của class.
	``` Example
	class Player
	{
	    private int hp;
	    // Property để tương tác
	    public int HP
	    {
        get { return hp; } // Cho phép đọc giá trị
        set 
        { 
            // Kiểm soát logic: Máu không bao giờ được nhỏ hơn 0
            // value là từ khóa đại diện cho giá trị mới mà ngoài class muốn gán cho property HP
            if (value < 0) hp = 0;
            else hp = value; 
        }
    }
	```
	- Ngoài ra còn có tính năng **Auto-property** viết tắt: `public int P {get; set;}`
# 2. Static 
-  Dùng để định nghĩa một biến là một thành phần của chính class đó (không của riêng từng đối tượng nào)
	
	``` Example
	class GameSettings
	{
	    // Biến static chung cho toàn bộ game
	    public static int playerLives = 3; 
	    public static void ShowInfo()
	    {
        Console.WriteLine("Chào mừng đến với GCC Simulator");
	    }
	}
	```
	
# 3. Kế thừa (Inheritance)
- Khi các class có nhiều điểm chung, có thể gom lại thành các class cha và con kế thừa để tái sử dụng
	``` Example
	// Class cha
	class Character
	{
	    public string Name;
	    public void Die() { Console.WriteLine("Đã chít"); }
	}

	// Class con kế thừa Character
	class Monster : Character
	{
	    public int ferocity; 
	    // Độ hung dữ riêng của quái mà Character không cần
	}
	```
# 4. Đa hình
- Sử dụng `virtual` và `override` cho phép class con ghi đè (định nghĩa lại) hành vi của class cha.
	``` Example
	class Hello
	{
	    public virtual void MakeSound() { Console.WriteLine("Xin chào thế giới"); }
	}
	class GCC : Hello
	{
	    public override void MakeSound() { Console.WriteLine("Xin chào GCC!"); }
	}
	//Chỉ có biến virtual mới được phép bị override
	```
	- Ngoài ra còn `abstract` nhưng hơi khó hiểu với em ạ.
# 5. Destructor
	....
# 6. [MonoBehaviour](https://docs.unity3d.com/6000.5/Documentation/ScriptReference/MonoBehaviour.html)
- Là một class cơ sở mà mọi script đều phải kế thừa để có thể gắn vào các `GameObject` trong Unity (Nếu muốn).
	- Nó sẽ có vòng đời (Order of execution) là tập hợp những các `Methods` được Unity tự động gọi theo một trình tự thời gian xác định từ lúc một `Object` được sinh ra cho đến khi hủy.
		1.  Nhóm khởi tạo (Chỉ chạy một lần duy nhất trong vòng đời)
			- `Awake()`: Chạy khi script instance được tải kể cả khi `GameObject` bị tắt. Dùng để khởi tạo các biến nội bộ, gán các tham chiếu giữa các component trên cùng 1 `Object` 
			- `OnEnable()`: Chạy khi `GameObject` hoặc Script được bật (`enabled=true`). Có thể chạy nhiều lần nếu `Object` tắt đi bật lại
			- `Start()`: Chạy khi tất cả các hàm `Awake()` khác của các script đã chạy xong và chỉ chạy đúng một lần ở frame đầu tiên. Dùng để lấy đối tượng khác trong Scene.
		2. Nhóm lặp theo Frame Rate
			- `FixedUpdate()`: Chạy theo interval cố định (mặc định là 0.02s/lần), không bị phụ thuộc vào cấu hình của máy hay FPS. Dùng để tính toán vật lý.
			- `Update()`: Chạy một lần mỗi frame, FPS càng cao thì chạy càng nhiều lần, càng thấp thì chạy càng ít. Dùng để nhận input từ người chơi, xử lí logic (ví dụ như [Geometry Dash](https://www.geometrydash.com/) )
			- `LateUpdate()`: Chạy sau khi các hàm Update đã chạy xong. Thường dùng cho camera để đuổi theo nhân vật.
		3. Nhóm kết thúc (Khi tắt game hoặc hủy `Object`)
			- `OnDisable()`: Chạy khi script hoặc `GameObject` bị tắt (`SetActive(false)`). Thường dùng để hủy sự kiện Event Listener.
			- `OnDestroy()`: Chạy khi đối tượng bị xóa khỏi bộ nhớ hoặc khi thoát game. Dùng để... thoát game.
	- Thứ tự gọi: `Awake -> OnEnable -> Start -> (FixedUpdate -> Update -> LateUpdate)`
# 7. Vector
- `Vector2`: Dùng cho không gian 2D, gồm 2 thành phần x (hoành độ) và y (tung độ).
- `Vector3`: Dùng cho không gian 3D, gồm 3 thành phần là x và y của `Vector2` và trục z (Rotation của 2D). Trục z vẫn có thể được dùng cho game 2D và hành động như việc xoay `GameObject`.
- Vận tốc và hướng đi của `GameObject`: 
	``` Example
	// Di chuyển nhân vật sang phải mỗi frame (trong hàm Update)
	 transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
	```
- Các hướng Vector có sẵn trong Unity:
		- `Vector3.zero` -> `(0, 0, 0)`
		- `Vector3.one` ->`(1, 1, 1)`
		- `Vector3.up` ->`(0, 1, 0)`
		- `Vector3.down` -> `(0, -1, 0)`
		- `Vector3.right` -> `(1, 0, 0)`
		- `Vector3.left` ->`(-1, 0, 0)` 
		- `Vector3.forward` -> `(0, 0, 1)`
		- `Vector3.back` -> `(0, 0, -1)`
- Các phép toán với Vector trong Unity:
	- `Vector3.Distance(position 1, position 2)`: Tính khoảng cách giữa 2 `Object`.
	- `.normalized`: Dùng để chuẩn hóa Vector thành 1 Vector hướng (Vector đơn vị). `Vector3 direction = direction.normalized`.
	- `Vector3.Lerp(position 1, position 2, float tỉ lệ)`: Dùng để làm mượt chuyển động. Chuyển động từ position 1 -> position 2 với khoảng cách là `tỉ lệ`, tức là sẽ di chuyển được `tỉ lệ`% quãng đường khi được gọi, khi được dùng trong hàm `Update()` và được nhân với `deltaTime` thì sẽ tạo được hiệu ứng chuyển động mượt.
# 8. Time
- `Time.deltaTime`: Khoảng cách giữa 2 lần update/2 frame, game càng lag thì deltaTime càng cao, càng mượt thì deltaTime càng thấp.
- `Time.fixedDeltaTime`: giống `deltaTime` nhưng theo một interval (0.02s).
- `Time.UnscaledDeltaTime`: Là `deltaTime` nhưng không bị ảnh hưởng bởi `timeScale`
- `Time.timeScale`: Tick / Tốc độ của game.
# 9. Mathf
- Là một `static class` có sẵn trong Unity. Được dùng để xử lí logic game.
	- `Mathf.Clamp`: Giới hạn cho 1 biến không vượt mức ~~Pickleball~~ cho phép (Máu không được âm, v.v)
	- `Mathf.Round`: Làm tròn 1 số tới giá trị gần nhất
	- `Mathf.Floor`: Làm tròn xuống 1 số.
	- `Mathf.Ceil`: Làm tròn lên 1 số.
	- `Mathf.Abs`: Giá trị tuyệt đối.
	- `Mathf.Min`: So sánh 2 giá trị và lấy giá trị nhỏ hơn.
	- `Mathf.Max`: So sánh 2 giá trị và lấy giá trị lớn hơn.
	- `Mathf.Sin/Cos/Tan`: Dùng để tính toán quỹ đạo (ví dụ: Item bị rơi trong Minecraft).
# 10. Gizmos
- Là công cụ dùng để vẽ trong Unity, chỉ có thể được hiển thị ở trong scene view bằng cách bật Gizmos lên.
- Để vẽ được thì dùng thông qua 2 hàm callback trong `MonoBehaviour`:
	- `OnDrawGizmos()`: Được gọi bởi Unity ở mỗi frame không điều kiện.
	- `OnDrawGizmosSelected()`: Chỉ được chạy khi chọn đúng `GameObject` có chứa script chứa Gizmos.
- Cách để vẽ cơ bản:
	- `Gizmos.color`: Chỉnh màu của Gizmos được tạo.
	- `Gizmos.DrawLine/Cube/WireCube/...`: Vẽ đủ các loại hình..
# 11. Transform
- Là 1 component bắt buộc phải có trong mỗi `GameObject`.
- Dùng để xác định vị trí, di chuyển, xoay `GameObject`:
	- `transform.position`: Vị trí / Tọa độ của `GameObject` trong không gian game.
	- `transform.rotation`: Góc quay của `GameObject` dưới dạng Quaternion
	- `transform.localScale`: Kích thước tỉ lệ của `GameObject` theo trục `x;y;z`.
- Unity phân biệt hai hệ tọa độ riêng: `position` và `localPosition`.
	- `position`: Là tọa độ theo toàn không gian thế giới.
	- `localPosition`: Là tọa độ tương đối so với Parent của nó.
- Các hàm thao tác với Transform thường dùng: 
	- `transform.Translate: Dịch chuyển `GameObject` theo một hướng và một khoảng cách xác định. 
	- `transform.Rotate: Xoay `GameObject` theo các góc quay cho trước.
	- `transform.LookAt: Tự động xoay mặt/hướng của `GameObject` nhìn thẳng về phía một đối tượng hoặc vị trí mục tiêu. 
	- `transform.SetParent`: Thay đổi hoặc gán quan hệ cha - con cho `GameObject` (dùng khi nhặt item vào inventory hoặc thả ra).
END.