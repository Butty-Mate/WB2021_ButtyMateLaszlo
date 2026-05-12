<?php

namespace Database\Seeders;

use App\Models\User;
use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class DatabaseSeeder extends Seeder
{
    use WithoutModelEvents;

    /**
     * Seed the application's database.
     */
    public function run(): void
    {
        // User::factory(10)->create();

        DB::table('kategoriak')->insert([
            ['id' => 1, 'nev' => 'Haz'],
            ['id' => 2, 'nev' => 'Lakas'],
            ['id' => 3, 'nev' => 'Epitesi telek'],
            ['id' => 4, 'nev' => 'Garazs'],
            ['id' => 5, 'nev' => 'Mezogazdasagi terulet'],
            ['id' => 6, 'nev' => 'Ipari ingatlan'],
        ]);
    }
}
