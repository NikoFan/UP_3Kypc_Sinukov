use UPdatabase

-- �������� ������� ��������
create table ��������(
[ID ���������] int primary key not null,
������� nchar(11) not null,
��� nchar(50) not null,
����� nchar(30) not null,
������ nchar(15) not null,
���� nchar(20) not null
)

-- �������� ������� ��������
create table ��������(
[ID ���������] int primary key not null,
������� nchar(11) not null,
��� nchar(50) not null,
����� nchar(30) not null,
������ nchar(15) not null,
���� nchar(20) not null
)


-- �������� ������� ������
create table ������(
[ID �������] int primary key not null,
������� nchar(11) not null,
��� nchar(50) not null,
����� nchar(30) not null,
������ nchar(15) not null,
���� nchar(20) not null
)

-- �������� ������� ��������
create table ��������(
[ID ���������] int primary key not null,
������� nchar(11) not null,
��� nchar(50) not null,
����� nchar(30) not null,
������ nchar(15) not null,
���� nchar(20) not null
)


create table ������(
[ID ������] int primary key not null,
[���� ����������] date not null,
[��� �������] nchar(30) not null,
[������ �������] nchar(100),
�������� nchar(300),
������ nchar(20) not null,
[���� ���������] date,
�������� nchar(200),

[ID �������] int,
-- ��������� ���� �� ID �������
FOREIGN KEY ([ID �������]) REFERENCES ������ ([ID �������]),

[ID ���������] int not null,
-- ��������� ���� �� ID ���������
FOREIGN KEY ([ID ���������]) REFERENCES �������� ([ID ���������]),
)

-- ������ � ���� ����������� � �������
create table �����������(
[ID �����������] int primary key not null,
��������� nchar(300) not null,
[ID �������] int not null,
FOREIGN KEY ([ID �������]) REFERENCES ������ ([ID �������]),
[ID ������] int not null,
FOREIGN KEY ([ID ������]) REFERENCES ������ ([ID ������])
)


