use SushiTest1

INSERT Category
( NameRus, NameUkr)
VALUES
('�����', '����'),
('����', '������'),
('������', '����'),
('����', '����'),
('�����', '�����'),
('�������', '����')
GO

INSERT OrderStatus
( StatusNameRus, StatusNameUkr)
VALUES
('��������', '�������'),
('� ��������', '� ���������'),
('�� ������ ', '�� ���������'),
('�������', '������'),
('������', '���������'),
('� ����������','� ���������')
GO

INSERT Product
(CategoryId,NameRus,NameUkr,NumberOfOrders,Count,Energy,Balance,Price,Sale)
VALUES
('1','�������������� �����', '�������������� ����','5','6','420','40','63','0'),
('1','��� ����', '�� ���','0','6','300','40','31','0'),
('1','������ ������', '������ ������','0','6','340','40','72','0'),
('1','����� ����', '����� ���','0','6','440','40','57','1'),
('1','����������� � �����', 'Գ��������� � �����','0','6','280','40','46','0'),
('1','���� ����', '���� ���','0','6','420','40','60','0'),
('4','���� ���', '���� ���','0','6','368','40','50','0'),
('4','���� � ��������������', '���� � ��������������','0','1','400','40','24','0'),
('4','����-����', '̳��-����','0','1','410','40','33','0'),
('4','����-���� � �����', '̳��-���� � �����','8','1','420','40','42','0'),
('4','����-���� � �������', '̳��-���� � �������','0','1','430','40','24','1'),
('2','���� ����', '���� ���','0','1','930','40','240','0'),
('2','����������� �������', '����������� �������','0','1','830','40','245','0'),
('2','������� ���', '�������� ���','0','1','730','40','233','0'),
('2','����', '����','0','1','1230','40','244','0'),
('2','��������� ��������', '������� �����糿','0','1','1010','40','950','0'),
('6','������� ��������', '������� ��������','0','1','100','40','23','0'),
('6','������� ��������', '������� ��������','0','1','120','40','22','1'),
('6','������� ����������� � �����', '������� ��������� � �����','0','1','80','40','19','0'),
('5','���� ���������', '���� �ó�������','0','1','12','40','7','0'),
('5','���� ���������', '���� ���������','0','1','12','40','8','0')
GO

INSERT ProductWeightDetails
(ProductId, Name, Value)
VALUES
('1','������','190'),
('2','������','220'),
('3','������','250'),
('4','������','210'),
('5','������','180'),
('6','������','230'),
('7','������','310'),
('8','��','300'),
('9','��','400'),
('10','��','320'),
('11','��','440'),
('12','������','840'),
('13','������','740'),
('14','������','780'),
('15','������','970'),
('16','������','1020'),
('17','��','440'),
('18','��','470'),
('19','��','530'),
('20','������','30'),
('21','������','30')
GO

INSERT AdditionProductsForProduct
(ProductId, ProductAdditionId)
VALUES
(1,21),
(2,21),
(3,21),
(4,21),
(5,21),
(6,21),
(1,20),
(2,20),
(3,20),
(4,20),
(5,20),
(6,20),
(12,21),
(13,21),
(14,21),
(15,21),
(16,21),
(12,20),
(13,20),
(14,20),
(15,20),
(16,20)
GO



