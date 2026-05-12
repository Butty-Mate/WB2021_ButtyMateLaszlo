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
            ['id' => 1, 'nev' => 'Tracking tura'],
            ['id' => 2, 'nev' => 'Teljesitmeny tura'],
            ['id' => 3, 'nev' => 'Jelvenyszerzo tura'],
            ['id' => 4, 'nev' => 'Kerekpartura'],
            ['id' => 5, 'nev' => 'Evezos tura'],
            ['id' => 6, 'nev' => 'Magashegyi expedicio'],
        ]);
    }
}
