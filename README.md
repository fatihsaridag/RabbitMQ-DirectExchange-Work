## Direct Exchange'in yapmış oldugu işlem ##

Producer tarafından bir mesaj geldiğinde bu mesajı route bilgisine göre ilgili kuyruğa gönderiyor. Mesela gelen mesajın routue ' unda "Critical-route" yazıyor ise yukarıdaki kuyruğa gidecektir. 

## Seneryomuz nasıl olabilir ? ##
1) Biz rastgele log seviyelerine bağlı mesajlar gönderelim. Crtical Mesage , Error messagge , warning message  , Info message 
2) Ve gelen mesaja da bir route belirleyelim 
3) Kuyrukları da producer tarafında oluşturacağız. Biz bir mesaj gönderdiğimiz zaman bu mesajın yukarıdaki kuyruğa gitmesini istediğimiz zaman route ismine critical-route vericez.
4) Direct Exchange ise ilgili mesajı ilgili route ile kuyruğa ulaştıracaktır.

![2](https://user-images.githubusercontent.com/68101192/208645210-72c990dc-6fd9-4450-bc80-99f0cdbb7ba3.PNG)


## Gerçek hayatta ##
1) Kuyruktan gelen Criticalları veri tabanına kaydedelim
2)  Kuyruktan gelen Errorları bir file dosyasına kaydedelim. 
3)  Kuyruktan gelen Infoları grafiksel olarak kaydedelim vs.  
4)  Yani cunsomerlar tamamen bağımsız istediğini yapabilirler.
5)  İlgili Cunsomer mesaja kuyruğa bağlanıp mesajı okudukça mesajlar kuyruktan silinecek.

<br/>
<br/>
## Direct Exchange Konsol Çalışması ##



![1](https://user-images.githubusercontent.com/68101192/208645325-8c7c855f-4989-43a1-8de8-e61f4cff3893.png)
![2](https://user-images.githubusercontent.com/68101192/208645336-db520720-5400-453c-a390-f0c4bddf83a9.png)
![3](https://user-images.githubusercontent.com/68101192/208645315-6fa0f330-3bed-4906-8f36-6b81e4423d02.png)
![Ekran Alıntısı](https://user-images.githubusercontent.com/68101192/208645364-97dd75d3-879b-4681-94cc-6b44b4b6cfa4.PNG)
