﻿// <auto-generated />
using System;
using Evbul.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Evbul.Migrations
{
    [DbContext(typeof(EvbulContext))]
    partial class EvbulContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("EvOzellik", b =>
                {
                    b.Property<int>("EvlerEvId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OzelliklerOzellikId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EvlerEvId", "OzelliklerOzellikId");

                    b.HasIndex("OzelliklerOzellikId");

                    b.ToTable("EvOzellik");
                });

            modelBuilder.Entity("Evbul.Entity.Ev", b =>
                {
                    b.Property<int>("EvId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aciklama")
                        .HasColumnType("TEXT");

                    b.Property<bool>("AktifMi")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Banyo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Baslik")
                        .HasColumnType("TEXT");

                    b.Property<int>("Fiyat")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<int>("Kapasite")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<int>("YatakOdasi")
                        .HasColumnType("INTEGER");

                    b.Property<int>("YatakSayisi")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("YayinlamaTarihi")
                        .HasColumnType("TEXT");

                    b.HasKey("EvId");

                    b.HasIndex("KullaniciId");

                    b.ToTable("Evler");
                });

            modelBuilder.Entity("Evbul.Entity.Kullanici", b =>
                {
                    b.Property<int>("KullaniciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Eposta")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("KullaniciAd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Parola")
                        .HasColumnType("TEXT");

                    b.HasKey("KullaniciId");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("Evbul.Entity.Ozellik", b =>
                {
                    b.Property<int>("OzellikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Renk")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<string>("Yazi")
                        .HasColumnType("TEXT");

                    b.HasKey("OzellikId");

                    b.ToTable("Ozellikler");
                });

            modelBuilder.Entity("Evbul.Entity.Yorum", b =>
                {
                    b.Property<int>("YorumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EvId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("TEXT");

                    b.Property<string>("Yazi")
                        .HasColumnType("TEXT");

                    b.HasKey("YorumId");

                    b.HasIndex("EvId");

                    b.HasIndex("KullaniciId");

                    b.ToTable("Yorumlar");
                });

            modelBuilder.Entity("EvOzellik", b =>
                {
                    b.HasOne("Evbul.Entity.Ev", null)
                        .WithMany()
                        .HasForeignKey("EvlerEvId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Evbul.Entity.Ozellik", null)
                        .WithMany()
                        .HasForeignKey("OzelliklerOzellikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Evbul.Entity.Ev", b =>
                {
                    b.HasOne("Evbul.Entity.Kullanici", "Kullanici")
                        .WithMany("Evler")
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("Evbul.Entity.Yorum", b =>
                {
                    b.HasOne("Evbul.Entity.Ev", "Ev")
                        .WithMany("Yorumlar")
                        .HasForeignKey("EvId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Evbul.Entity.Kullanici", "Kullanici")
                        .WithMany("Yorumlar")
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ev");

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("Evbul.Entity.Ev", b =>
                {
                    b.Navigation("Yorumlar");
                });

            modelBuilder.Entity("Evbul.Entity.Kullanici", b =>
                {
                    b.Navigation("Evler");

                    b.Navigation("Yorumlar");
                });
#pragma warning restore 612, 618
        }
    }
}
