using System;

namespace TodoList {
    class Program {
        public static string[] model = new string[10];

        static void Main(string[] args) {
            ViewShowTodoList();
        }

        private static void ViewShowTodoList() {
            while (true) {
                Console.Clear();
                ShowTodoList();

                Console.WriteLine("MENU : ");
                Console.WriteLine("1. Tambah");
                Console.WriteLine("2. Hapus");
                Console.WriteLine("x. Keluar");

                var input = Input("Pilih");

                if (input.Equals("1")) {
                    ViewAddTodoList();
                    Console.ReadKey();
                }
                else if (input.Equals("2")) {
                    ViewRemoveTodoList();
                    Console.ReadKey();
                }
                else if (input.Equals("x")) {
                    break;
                }
                else {
                    Console.WriteLine("Pilihan tidak dimengerti");
                    Console.ReadKey();
                }
            }
        }

        private static void ShowTodoList() {
            Console.WriteLine("TODOLIST");
            for (var i = 0; i < model.Length; i++) {
                var todo = model[i];
                var no = i + 1;
                if (todo != null) {
                    Console.WriteLine(no + ". " + todo);
                }
            }
        }

        private static void ViewRemoveTodoList() {
            Console.WriteLine("MENGHAPUS TODOLIST");

            var no = Input("Nomor yang Dihapus (x Jika Batal)");
            if (no.Equals("x")) { }
            else {
                bool success = RemoveTodoList(int.Parse(no));
                if (!success) {
                    Console.WriteLine("Gagal menghapus todolist : " + no);
                }
            }
        }

        private static bool RemoveTodoList(int no) {
            if ((no - 1) >= model.Length) {
                return false;
            }

            if (model[no - 1] == null) {
                return false;
            }

            for (var i = no - 1; i < model.Length; i++) {
                if (i == (model.Length - 1)) {
                    model[i] = null;
                }
                else {
                    model[i] = model[i + 1];
                }
            }

            return true;
        }

        private static void ViewAddTodoList() {
            Console.WriteLine("MENAMBAH TODOLIST");

            var todo = Input("Todo (x Jika Batal)");

            if (todo.Equals("x")) { }
            else {
                AddTodoList(todo);
            }
        }

        private static void AddTodoList(string todo) {
            var isFull = true;
            foreach (var item in model) {
                if (item != null) continue;
                // array model belum penuh
                isFull = false;
                break;
            }

            // saat penuh array diresize jadi 2x kapasitasnya
            if (isFull) {
                var temp = model;
                model = new string[model.Length * 2];

                for (var i = 0; i < temp.Length; i++) {
                    model[i] = temp[i];
                }
            }

            // data ditambahkan ke index array yang pertama null
            for (var i = 0; i < model.Length; i++) {
                if (model[i] != null) continue;
                model[i] = todo;
                break;
            }
        }

        private static string Input(string info) {
            Console.Write(info + " : ");
            var data = Console.ReadLine();
            return data;
        }
    }
}