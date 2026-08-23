## Class
1. Học về khái niệm của class.
	 - Là một bản thiết kế hay 1 khuôn mẫu.
	 - Object là vật thể dựa trên khuôn đó.
2. Cấu trúc của 1 class.
     - Bao gồm Fields và Methods (Thuộc tính và phương thức).
	    ``` Example
 	    public class Player
 	    {
 		    // Đây là 2 thuộc tính của class Player
 		    private int hp;
 		    private int attack;
 		    // Đây là 1 Method của class Player
 		    public void takeDamage(int damage)
 		    {
 				hp-=damage;
 		    }
 	    }
	    ```
3. Constructor của 1 class.
	 -  Là một hàm khởi tạo để gán giá trị ban đầu cho các field của 1 class.
	  ``` Example
	  public class Player
	  {
		  private int hp;
		  // Đây là 1 constructor
		  public Player(int hp){
			  this.hp=hp;
		  }
	  }
	  //Khởi tạo giá trị cho Player
	  Player Ky = new Player(100);
	  ```
## Ref / Out
1. Ref
	- Dùng để truyền 1 biến vào hàm theo tham chiếu, tác động trực tiếp vào ô nhớ của biến gốc.
	- Biến được truyền với ref phải có sẵn giá trị.
	``` Example
	public int Tung = 3;
    void Dec(ref int a)
    {
        a--;
    }
    Dec(ref int a);
    // Sẽ trả về 2 do đã tham chiếu qua ref, nếu không thì chỉ trả về 3 vì đang là tham trị.
	```
2. Out
	- Dùng như 1 cách để khai báo biến tạm ngay trong ô giá trị truyền vào
	``` Example
	void Dec1(out int a)
    {
        a = 3;
        Console.WriteLine(a);
    }
    // Sẽ trả về 3 mà không cần khai báo hẳn biến a!
	```
