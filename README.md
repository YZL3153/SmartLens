# SMARTLENS ❔  
Bu projede, görme engelli bireyler için, bulut teknoloji ve derin öğrenme destekli yapay görme sistemi geliştirme amaçlandı.

#Çalışma prensibi ❔
Görme engelli bireyin telefonunda'ki mobil uygulama ile etrafında'ki nesnelerin görüntüleri çekilip merkezi sunucuya iletilir. Merkezi sunucu ise load balancing yaparak ilgili musait nesne tanıma sunucusuna iletir. Ve nihai sonuçlar üretildikten sonra geriye merkezi sunucuya cevaplar gönderilir ve son olarak görme engelli bireye ulaşır ve sesli çıktı üretilir.

Merkezi sunucudan kısaca bahsedecek olursak, projenin bir merkezi sunucusu(.NET CORE) var. Bu sunucuyu; Load balancing, crud, auth, validation, aspect gibi işlemlerimizi
yapmak için kullanıyoruz. 

#Load balancing neden kullanıyoruz ❔
Nesne tanıma yük bakımından maliyetli bir işlemdir. Sunucu üzerinde dikey ölçekleme(daha güçlü bir sunucu) yapmak yerine,
yatay ölçekleme(aynı performans ile daha fazla sunucu) yapmayı tercih ettik. Dolayısıyla merkezi sunucumuz yanında asıl nesne tanıma işlemlerimiz için,
python kullandık. Python ile ile yazdığımız birden fazla instance'ı farklı farklı sunucularda deploy ettik.
Merkezi sunucumuz kendisine gelen bir görüntü bilgisini #"load balancing" yaparak musait sunuculara iletmektedir. İlgili sunucu aldığı görüntüyü model'den geçirerek,
çıkan sonucu bir array olarak geriye merkezi sunucuya iletmektedir. Son olarak validator işleminden sonra yanıtlar isteği gönderen istemciye ulaşır.



#KURULUM VE KULLANIM  🚀 

 ❗️ Bilgisayarınızda  anaconda "5.1.0" versiyonu kurulu değilse veya Tensorflow "1.13.2" sürümü kurulu değilse aşağıda # GENEL KURULUMLAR adımlarını takip edin.

➡️ Öncelikle proje dosyalarını indiriyoruz.

➡️ Daha sonra server/src/SmartLens.sln dosyasını açarak merkezi sunucu projesini açmış oluruz. 

➡️ Projemizi derleyelim ve çalıştıralım. Merkezi sunucu başlayacaktır.

➡️ Daha sonra server/object_detection/image_detected.bat ile python uygulamasını çalıştıralım. Veya cmd ile; python image_detected.py yazarak scripti çalıştırabilirsiniz.

➡️ Nesne tanıma sunucusu başlamış oldu ve merkezi sunucudan verileri bekliyor.

➡️ Daha sonra istemci olarak, .net ile test amaçlı yazılan projeyi açıyoruz. Bunun için; client/SmartLens.UITestClient/SmartLens.UITransmissionTestClient.sln 
projesini açarak derleyelim. İstemciyi sunucunun olduğu bilgisayarda çalıştırdığınız varsayılmıştır. Farklı bilgisayarlarda deneyecekseniz, ip adresini(varsayılan: 127.0.0.1) değiştirmeyi unutmayın.
➡️ Görüntü gönderimi başlamıştır. Sunucular ile istemciler arasında veri transferi sorunsuz ilerliyor olması gerekmektedir.

❗️ İstemci olarak, test istemcisi olduğundan bir kamera kullanılmamıştır. Görüntü olarak bilgisayarınızın sol üst köşesinden 500*500 çözünürlüğünde ekran kaydı göndermektedir.

Bir sorun halinde, tavsiye/öneri durumlarında veya geliştirme isteğiniz olduğunda bana bildirmenizden memnuniyet duyarım.

İletişim: halitakkus03@gmail.com



# GENEL KURULUMLAR
Tensorflow object detection api kullanmaktayız.
# Anaconda kurulumu

Anaconda 5.1.0 versiyonunu indirin. Bu versiyon tensorflow 1.13.2 versiyonu ile uyumludur.
Bulacağınız adres: https://repo.anaconda.com/archive/

# Tensorflow kurulumu

tensorflow krulumu için aşağıdaki komutu kullanın.

Paylaştığım dosyalar, 1.13.2 versiyonunu destekler.

pip install --upgrade tensorflow==1.13.2

Kurulum tamamlandıktan sonra aşağıdaki komutu çalıştırın.

>>> import tensorflow as tf
>>> hello = tf.constant('Hello, TensorFlow!')
>>> sess = tf.Session()
>>> print(sess.run(hello))



'Hello, TensorFlow!' mesajını alıyorsanız tensorflow kurulumu başarılı demektir.



