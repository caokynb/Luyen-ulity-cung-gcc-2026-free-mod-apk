1. Properties
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
	}
	```
	- Ngoài ra còn có tính năng **Auto-property** viết tắt: `public int P {get; set;}`
2. Static 
	- Dùng để định nghĩa một biến là một thành phần của chính class đó (không của riêng từng đối tượng nào)
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
3. Kế thừa (Inheritance)
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
4. Đa hình
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
5. Destructor
	....
6. [MonoBehaviour](https://docs.unity3d.com/6000.5/Documentation/ScriptReference/MonoBehaviour.html)
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
7. Vector
8. Time
	- `Time.deltaTime`: Khoảng cách giữa 2 lần update/2 frame, game càng lag thì deltaTime càng cao, càng mượt thì deltaTime càng thấp.
	- `Time.fixedDeltaTime`: giống `deltaTime` nhưng theo một interval (0.02s).
	- `Time.UnscaledDeltaTime`: Là `deltaTime` nhưng không bị ảnh hưởng bởi `timeScale`
	- `Time.timeScale`: Tick của game
9. Mathf
10. Gizmos
	- 
11. Transform
END.