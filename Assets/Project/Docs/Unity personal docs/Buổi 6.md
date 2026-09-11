## 1. Sự kiện trong Unity
- Có 3 loại sự kiện trong Unity:
1. **C# Action**
	- Là một delegate (con trỏ hàm) có sẵn trong thư viện `System`.
	- Tác dụng giúp một script có thể báo tin nhưng không quan trọng là script nào lắng nghe hay xử lí thông báo. Các script khác chỉ cần đăng ký để nhận thông báo đó.
	- Ví dụ như khi bắt đầu game thì sẽ có một số xu nhất định chẳng hạn.
	- Có 2 kiểu khai báo:
		- Có tham số truyền vào: Thông báo kèm với tham số.
		- Không có tham số truyền vào: Chỉ có thông báo mà không có tham số.
	- Cách sử dụng:
	``` Example
	public class CoinManager : MonoBehaviour
	{
		// Khai báo Action không có tham số truyền vào
		public static Action onCoinCollected;
		// Khai báo có tham số truyền vào (truyền số xu mới)
		public static Action<int> onCoinChanged;
		
		public void Start(){
			int totalCoins=5;
			// Phát sự kiện = Invoke cho cả game
			// Dùng dấu "?" tránh lỗi khi chưa có script khác đăng kí sự kiện 
			onCoinChanged?.Invoke(totalCoins);
		}
	}
	```

``` Example
// Nhận thông báo từ script trên
public class Coin : MonoBehaviour
{
	private int currentCoin=0;
	void OnEnable()
	{
		// không phải là cộng mà là thêm vào hàng chờ để lắng nghe thông báo
		CoinManager.onCoinChanged += UpdateCoin;
	}
	
	void OnDisable()
	{
		// hủy đăng kí lắng nghe thông báo
		CoinManager.onCoinChanged -= UpdateCoin;
	}
	
	void UpdateCoin(int coins)
	{
		//vì action khai báo có tham số nên tự động truyền vào luôn
		currentCoins+=coins;
		Debug.Log($"Hiện tại có {currentCoins} xu!")
	}
}
```
2. **Delegate** 
	- Là một kiểu dữ liệu được dùng để lưu các `Methods`, tưởng tượng nó như một chiếc khuôn mẫu.
	- Nó định nghĩa một `Method` phải có cấu trúc như nào thì mới được lưu trong nó (nhận bao nhiêu tham số,  trả về kiểu dữ liệu gì.
	- Delegate chỉ là nền tảng cốt lõi của `Action` và `Func` , đừng có dùng...
	- Cách dùng:
``` Example
// Khai báo một delegate
public delegate void OnMathOperate(int a,int b);
// Chỉ nhận những hàm mà truyền vào 2 tham số và trả về void

void OperationPlus(int a,int b)
{
	Debug.Log(a+b);
}

void OperationMinus(int a,int b)
{
	Debug.Log(a-b);
}

void Start()
{
	// tạo biến
	OnMathOperate calculator;
	
	// Lưu hàm cộng vào
	calculator += OperationPlus;
	
	// gọi như này thì sẽ thực hiện hàm OperationPlus
	calculator(1,2);
	
	// thêm hàm trừ vào
	calculator -= OperationMinus;
	
	// Giờ thì nó sẽ thực hiện cả 2 hàm lần lượt
	calculator(5,5);
	
}
```
3. **UnityEvent**
	- Là một class trong thư viện `UnityEngine.Events` .
	- Cho phép tạo các sự kiện hiển thị trực tiếp trên Inspector.
	- Thay vì phải tự thêm vào hàng thì chỉ cần kéo một `GameObject` và chọn hàm cần chạy ngay trong Inspector
	- Cách sử dụng (3 bước):
		1. Khai báo và cấu hình trên Inspector.
		```
		public int InteractableObject : MonoBehaviour 
		{ 
			// Tạo một UnityEvent hiển thị trên Inspector 
			public UnityEvent onInteract; 
			void Update() {
				// Giả lập khi người chơi bấm phím E để tương tác 
				if (Input.GetKeyDown(KeyCode.E)) {
					// Phát sự kiện
					onInteract?.Invoke(); 
				} 
			} 
		} 
		```
		2. Kéo vào Inspector.
			- Kéo script vào `GameObject` , sẽ xuất hiện mục là `On Interact` có thể kéo thêm bất kì `GameObject` khác vào.
		3. Đăng ký qua code (Optional).
		``` Example
		void Start()
		{
		    // Đăng ký hàm PlaySound thông qua code
		    onInteract.AddListener(PlaySound);
		}

		void PlaySound()
		{
		    Debug.Log("Đã phát âm thanh!");
		}
		```
## 2. Coroutine
- Thay vì chạy tất cả các lệnh trong 1 frame như `Update()` thì Coroutine có thể chia nhỏ từng tác vụ ra lần lượt từng frame.
- Chia các tác vụ ra bằng `yield return`.
- Chạy hết trên luồng chính, không chia luồng.
- Cách dùng `yield return WaitForSeconds:
``` Dùng yield return WaitForSeconds
public class PlayerDash : MonoBehaviour
{
    private bool canDash = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            Dash();
            // Bắt đầu đếm ngược thời gian hồi chiêu
            StartCoroutine(DashCooldownRoutine());
        }
    }

    void Dash()
    {
        Debug.Log("Nướt!");
    }
	
	// Khởi tạo 1 hàm Coroutine
    IEnumerator DashCooldownRoutine()
    {
        canDash = false; // tắt lướt
        Debug.Log("Đang hồi chiêu");

        // Tạm dừng đoạn code này trong 1 giây (game vẫn chơi bình thường)
        yield return new WaitForSeconds(1f);

        canDash = true; // hết cooldown lướt
        Debug.Log("Đã hồi chiêu xong!");
    }
}
```
- Dùng `yield return null`
``` c
public class SimpleYield : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(TestYieldNull());
    }

    IEnumerator TestYieldNull()
    {
        Debug.Log("Dòng này chạy ở Frame thứ 1.");
		// cơ bản là return null ném cái dòng tiếp theo vào frame sau thay vì đợi bao nhiêu giây.
        yield return null; 

        Debug.Log("Dòng này chạy ở Frame thứ 2.");
    }
}
```





