PGDMP         1    
            v            AVGDB    10.5    10.5                 0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                       false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                       false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                       false                       1262    16590    AVGDB    DATABASE     �   CREATE DATABASE "AVGDB" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Dutch_Netherlands.1252' LC_CTYPE = 'Dutch_Netherlands.1252';
    DROP DATABASE "AVGDB";
             postgres    false                        2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
             postgres    false                       0    0    SCHEMA public    COMMENT     6   COMMENT ON SCHEMA public IS 'standard public schema';
                  postgres    false    3                        3079    12924    plpgsql 	   EXTENSION     ?   CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;
    DROP EXTENSION plpgsql;
                  false                       0    0    EXTENSION plpgsql    COMMENT     @   COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';
                       false    1            �            1259    16598    Pictures    TABLE     �   CREATE TABLE public."Pictures" (
    "ID" integer NOT NULL,
    "Title" text,
    "Date" timestamp without time zone NOT NULL,
    "Description" text,
    "Location" text,
    "Path" text
);
    DROP TABLE public."Pictures";
       public         postgres    false    3            �            1259    16596    Pictures_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."Pictures_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public."Pictures_ID_seq";
       public       postgres    false    3    198                       0    0    Pictures_ID_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public."Pictures_ID_seq" OWNED BY public."Pictures"."ID";
            public       postgres    false    197            �            1259    16609    Services    TABLE     �   CREATE TABLE public."Services" (
    "ID" integer NOT NULL,
    service text,
    "AvailableDate" timestamp without time zone NOT NULL,
    "Description" text,
    "Price" double precision NOT NULL,
    "PicPath" text,
    "VideoPath" text
);
    DROP TABLE public."Services";
       public         postgres    false    3            �            1259    16607    Services_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."Services_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public."Services_ID_seq";
       public       postgres    false    3    200                       0    0    Services_ID_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public."Services_ID_seq" OWNED BY public."Services"."ID";
            public       postgres    false    199            �            1259    16620    Videos    TABLE     �   CREATE TABLE public."Videos" (
    "ID" integer NOT NULL,
    "Title" text,
    "Date" timestamp without time zone NOT NULL,
    "Description" text,
    "Location" text,
    "Path" text
);
    DROP TABLE public."Videos";
       public         postgres    false    3            �            1259    16618    Videos_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."Videos_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public."Videos_ID_seq";
       public       postgres    false    202    3                       0    0    Videos_ID_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public."Videos_ID_seq" OWNED BY public."Videos"."ID";
            public       postgres    false    201            �            1259    16591    __EFMigrationsHistory    TABLE     �   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         postgres    false    3            �
           2604    16601    Pictures ID    DEFAULT     p   ALTER TABLE ONLY public."Pictures" ALTER COLUMN "ID" SET DEFAULT nextval('public."Pictures_ID_seq"'::regclass);
 >   ALTER TABLE public."Pictures" ALTER COLUMN "ID" DROP DEFAULT;
       public       postgres    false    198    197    198            �
           2604    16612    Services ID    DEFAULT     p   ALTER TABLE ONLY public."Services" ALTER COLUMN "ID" SET DEFAULT nextval('public."Services_ID_seq"'::regclass);
 >   ALTER TABLE public."Services" ALTER COLUMN "ID" DROP DEFAULT;
       public       postgres    false    200    199    200            �
           2604    16623 	   Videos ID    DEFAULT     l   ALTER TABLE ONLY public."Videos" ALTER COLUMN "ID" SET DEFAULT nextval('public."Videos_ID_seq"'::regclass);
 <   ALTER TABLE public."Videos" ALTER COLUMN "ID" DROP DEFAULT;
       public       postgres    false    201    202    202                      0    16598    Pictures 
   TABLE DATA               ^   COPY public."Pictures" ("ID", "Title", "Date", "Description", "Location", "Path") FROM stdin;
    public       postgres    false    198   �        	          0    16609    Services 
   TABLE DATA               t   COPY public."Services" ("ID", service, "AvailableDate", "Description", "Price", "PicPath", "VideoPath") FROM stdin;
    public       postgres    false    200   �!                 0    16620    Videos 
   TABLE DATA               \   COPY public."Videos" ("ID", "Title", "Date", "Description", "Location", "Path") FROM stdin;
    public       postgres    false    202   �"                 0    16591    __EFMigrationsHistory 
   TABLE DATA               R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public       postgres    false    196   �#                  0    0    Pictures_ID_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Pictures_ID_seq"', 1, false);
            public       postgres    false    197                       0    0    Services_ID_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Services_ID_seq"', 1, false);
            public       postgres    false    199                       0    0    Videos_ID_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public."Videos_ID_seq"', 1, false);
            public       postgres    false    201            �
           2606    16606    Pictures PK_Pictures 
   CONSTRAINT     X   ALTER TABLE ONLY public."Pictures"
    ADD CONSTRAINT "PK_Pictures" PRIMARY KEY ("ID");
 B   ALTER TABLE ONLY public."Pictures" DROP CONSTRAINT "PK_Pictures";
       public         postgres    false    198            �
           2606    16617    Services PK_Services 
   CONSTRAINT     X   ALTER TABLE ONLY public."Services"
    ADD CONSTRAINT "PK_Services" PRIMARY KEY ("ID");
 B   ALTER TABLE ONLY public."Services" DROP CONSTRAINT "PK_Services";
       public         postgres    false    200            �
           2606    16628    Videos PK_Videos 
   CONSTRAINT     T   ALTER TABLE ONLY public."Videos"
    ADD CONSTRAINT "PK_Videos" PRIMARY KEY ("ID");
 >   ALTER TABLE ONLY public."Videos" DROP CONSTRAINT "PK_Videos";
       public         postgres    false    202            �
           2606    16595 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public         postgres    false    196               �   x����N�0�s�~��I�Pٕ]w��P(f��*q�x{����K���g��4<.���L�s�9�G��0Q/sBX|�#F�2 ��p���$����e<a��$`��7���뫖����}�e���[�i��y���{n+�tξ�Κ��ԉ�(������.��Vj�N����;A�OUZ)'���s�͍ڞ�%sE���{��h� 1j�      	   �   x��Ͻ�0���>�B[�AV]pb�g1!�^����-�ފ�q1:��������BH�@��h�]�	�B�)A^�M0r倣���h�P��g0J����U
�6�]+-���GSc���A��y��7��xo�ظ��d�&��Q]46���$e��iB�����6/	Y�����o��x��U\ݠb�Ա��NQ�wN��           x�}�?O�0���S����	U�f &��	]�Kr�cG�C$>=NLH�����Hp�iV��㈥�Y-��N�w� !ۋ(;�`It0�$@G�	N&h6<�%`�YM$�G��m��~Ԁ~��!-�Mk���ġN��~�Ȏ��Ցu�@�|%[6f�ʠ��%�Lh�<?�Q?�u֐�G�sp�a�?��?�Yꌕ��%8&x��H���r�
��pɾ��H�u�7�%���R�ȭ��yd��C��(u���"��/vU��         =   x�320�044��Ɔ��y�%��9�E��%��a�.I�Fz�z&�E%��ƆF&\1z\\\ �C#     