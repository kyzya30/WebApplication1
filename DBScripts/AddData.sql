INSERT Category
( NameRus, NameUkr, Priority)
VALUES
('�����', '����','6'),
('����', '������','5'),
('������', '����','1'),
('����', '����','3'),
('�����', '�����','2'),
('�������', '����','4')
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
(CategoryId,NameRus,NameUkr,NumberOfOrders,Count,Energy,Balance,Price,Sale,IsHided)
VALUES
('1','�������������� �����', '�������������� ����','5','6','420','40','63','0','FALSE'),
('1','��� ����', '�� ���','0','6','300','40','31','0','FALSE'),
('1','������ ������', '������ ������','0','6','340','40','72','0','FALSE'),
('1','����� ����', '����� ���','0','6','440','40','57','1','FALSE'),
('1','����������� � �����', 'Գ��������� � �����','0','6','280','40','46','0','FALSE'),
('1','���� ����', '���� ���','0','6','420','40','60','0','FALSE'),
('4','���� ���', '���� ���','0','6','368','40','50','0','FALSE'),
('4','���� � ��������������', '���� � ��������������','0','1','400','40','24','0','FALSE'),
('4','����-����', '̳��-����','0','1','410','40','33','0','FALSE'),
('4','����-���� � �����', '̳��-���� � �����','8','1','420','40','42','0','FALSE'),
('4','����-���� � �������', '̳��-���� � �������','0','1','430','40','24','1','FALSE'),
('2','���� ����', '���� ���','0','1','930','40','240','0','FALSE'),
('2','����������� �������', '����������� �������','0','1','830','40','245','0','FALSE'),
('2','������� ���', '�������� ���','0','1','730','40','233','0','FALSE'),
('2','����', '����','0','1','1230','40','244','0','FALSE'),
('2','��������� ��������', '������� �����糿','0','1','1010','40','950','0','FALSE'),
('6','������� ��������', '������� ��������','0','1','100','40','23','0','FALSE'),
('6','������� ��������', '������� ��������','0','1','120','40','22','1','FALSE'),
('6','������� ����������� � �����', '������� ��������� � �����','0','1','80','40','19','0','FALSE'),
('5','���� ���������', '���� �ó�������','0','1','12','40','7','0','FALSE'),
('5','���� ���������', '���� ���������','0','1','12','40','8','0','FALSE'),
('3','������� ��� ����','�������� ��� ����','0','0','12','40','2','0','FALSE'),
('3','������', '�����','0','1','12','40','1','0','FALSE'),
('3','������', '�����','0','1','12','40','1','0','FALSE')
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

