## 1. References
- [How to Setup Animator and Animations in Unity 2D](https://learn.unity.com/pathway/creative-core/unit/animation/tutorial/control-animation-with-an-animator)
## 2. Animator Controller
- Là một bảng điều khiển cho các Animation Clips (hoạt ảnh ấy ạ) của một `Object`, nó sẽ giống như một flowchart (sơ đồ td). Nó sẽ giúp quyết định được rằng khi nào thì cái `Object` đấy mới được chuyển sang hoạt ảnh khác bằng các điều kiện (Đứng yên -> di chuyển -> chít chẳng hạn).
- Thay vì viết code đổi từng khung hình thì chỉ cần ném vào Controller là xong.
- Cách tạo một Animation Controller (Cóp thẳng từ bạn em James Mini):
	1. **Tạo tài sản (Asset):**
	- Mở cửa sổ **Project** trong Unity.
	- Nhấp chuột phải vào thư mục bạn muốn lưu $\rightarrow$ Chọn **Create** $\rightarrow$ Chọn **Animator Controller**
	- Đặt tên cho Controller đó (ví dụ: `PlayerController`).
	2. **Gắn vào nhân vật:**
	- Bấm vào `GameObject` nhân vật của bạn trong cửa sổ **Hierarchy**.
	- Nhìn sang bảng **Inspector**, đảm bảo nhân vật có component **Animator**.
	- Kéo tệp `PlayerController` vừa tạo ở bước trên thả vào ô **Controller** trong component Animator đó.
	3. **Thiết lập bên trong:**
	- Nhấp đúp chuột vào tệp `PlayerController` để mở cửa sổ giao diện **Animator** (nếu không thấy, vào menu `Window > Animation > Animator`).
	- Tại đây, bạn sẽ thấy các khối mặc định như _Entry_, _Any State_, _Exit_ và bắt đầu kéo thả các **Animation Clip** của bạn vào đây để thiết lập các mối nối (Transitions).
## 3. Animator Component
- ... Là một component dùng như cầu nối giữa code với chuyển động.
- Với các điều kiện để chuyển hoạt ảnh khác thì component này sẽ đọc nó và thay đổi giá trị của các tham số đó. Cũng có thể chỉnh tốc độ phát giữa các clips
- **Các thông số quan trọng cần lưu ý:**
	- **Controller:** Nơi chứa bộ não hoạt ảnh liên kết với đối tượng.
	- **Avatar:** Dùng cho 3D nên bai bai.
	- **Apply Root Motion:** Thường không dùng đối với game 2D, vì nếu tích vào, hoạt ảnh sẽ tự điều khiển tọa độ nhân vật thay vì để code vật lý (`Rigidbody2D`) quản lý.
## 4. Animation Clip
- Là hoạt ảnh chuyển động của đối tượng. Nó lưu lại sự thay đổi của các thuộc tính theo thời gian để tạo thành ANIMATION.
- Cách tạo (James Mini):
	- Mở cửa sổ **Project**, nhấp chuột phải vào thư mục bạn muốn lưu $\rightarrow$ Chọn **Create** $\rightarrow$ **Animation**.
	- Đặt tên cho clip (ví dụ: `Player_Idle`, `Player_Run`).
	- **Thuộc tính quan trọng nhất - Loop Time:** (Trong file .anim không phải clip!) 
	    - **Nếu tích chọn:** Hoạt ảnh sẽ lặp đi lặp lại vô tận.
	    - **Nếu bỏ tích:** Hoạt ảnh chỉ chạy đúng một lần rồi dừng lại ở khung hình cuối.
## 4.5. Áp dụng
- Ví dụ khi di chuyển sẽ có animation và ngược lại với đứng yên (Idle):
	- **Bước 1**: Tạo Animation Clip (ở trên..)
	- **Bước 2**: Tạo parameter (điều kiện) Ở window Animator:
		- Nhìn sang cột phía bên trái của cửa sổ Animator, bấm vào tab **Parameters**.
		- Bấm dấu cộng **`+`** và chọn kiểu **Float** (hoặc **Bool**).
		- Đặt tên cho nó là **`Speed`** (hoặc `isWalking`). Tham số này sẽ là "cầu nối" nhận giá trị từ code.
	- **Bước 3**: Cài đặt Transition:
		- Trong cửa sổ Animator, sẽ có khối như là `Idle` và khối `Run`/`Walk` (Tùy tên đặt).
		- Nhấp chuột phải vào khối `Idle` $\rightarrow$ Chọn **Make Transition** $\rightarrow$ Kéo mũi tên sang khối `Run`.
		- Nhấp ngược lại từ khối `Run` $\rightarrow$ Chọn **Make Transition** $\rightarrow$ Kéo mũi tên về lại khối `Idle`.
		- Bấm vào mũi tên từ `Idle` sang `Run`:
		- Bỏ tích ô **Has Exit Time** (để chuyển động phản hồi ngay lập tức khi bấm phím, không bị trễ).
		- Ở phần **Conditions**, bấm dấu `+`, chọn điều kiện `Speed` **Greater**  `0.1`.
		- Bấm vào mũi tên từ `Run` sang `Idle`.
	    - Cũng bỏ tích **Has Exit Time**.
	    - Ở phần **Conditions**, chọn `Speed` **Lesser** `0.1`.
	- **Bước 4**: Code...
	``` c#
	public class PlayerMovement : MonoBehaviour
	{
		// code ngắn gọn cho dễ hiểu thôi... code cùng 1 script với movement luôn
	    [SerializeField] private Rigidbody2D rb;
	    public float walkSpeed = 5f;
	    
	    // Khai báo tham chiếu đến Animator Component
	    [SerializeField] private Animator animator; 
	    void Update()
	    { 
	        float moveInput = MoveAction.ReadValue<float>();
	        rb.linearVelocityX = walkSpeed * moveInput;
	
	        // Truyền giá trị tốc độ tuyệt đối vào Animator
	        animator.SetFloat("Speed", Mathf.Abs(moveInput));
	    }
	}
	```
- Thường thì khi di chuyển sẽ dùng parameter float rồi SetFloat (Đang đi và dừng).
- Còn Nhảy thì dùng Trigger thôi (chưa nhảy và đã nhảy) rồi dùng SetTrigger.
## 5. Blend Tree
- Là cái này: (Vòng triệu hồi SatungCL), em hiểu nó là gì mà... vừa dùng xong ở trên....
![[Pasted image 20260914164244.png]]
## 6. Finite State Machine
- Là một mô hình tư duy và kiến trúc lập trình được sử dụng để thiết kế các hệ thống có thể **tồn tại ở một thời điểm chỉ trong MỘT trạng thái duy nhất**, và có thể chuyển đổi qua lại giữa các trạng thái đó dựa trên các điều kiện cụ thể... 
- Khác với Blend Tree ở chỗ là đây là sẽ xây dựng một AI thay vì Animation như Blend Tree. Thật ra Blend Tree cũng là một dạng FSM.
- Cấu trúc cốt lõi của một FSM 2 trạng thái:
	``` C#
	using UnityEngine;

	public class SimpleFSM : MonoBehaviour
	{
    // 1. Định nghĩa các trạng thái có thể có
    private enum State { Idle, Run }
    private State currentState;
    void Start()
    {
        // Đặt trạng thái ban đầu khi game chạy
        currentState = State.Idle;
    }
    void Update()
    {
        // 2. Phân chia logic xử lý riêng cho từng trạng thái mỗi khung hình
        switch (currentState)
        {
            case State.Idle:
                Debug.Log("Đang đứng yên...");
                // Điều kiện chuyển sang Run
                if (Input.GetAxis("Horizontal") != 0)
                {
                    ChangeState(State.Run);
                }
                break;
            case State.Run:
                // --- Xử lý khi đang chạy ---
                Debug.Log("Đang chạy...");
                // Điều kiện chuyển về Idle
                if (Input.GetAxis("Horizontal") == 0)
                {
                    ChangeState(State.Idle);
                }
                break;
        }
    }

    // 3. Hàm chuyển đổi trạng thái chung
    void ChangeState(State newState)
    {
        currentState = newState;
    }
}
	```