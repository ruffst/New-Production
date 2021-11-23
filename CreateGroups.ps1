$BlockIds = @(

    <Block Type="MyObjectBuilder_OxygenGenerator" Subtype="" />
    <Block Type="MyObjectBuilder_OxygenGenerator" Subtype="OxygenGeneratorSmall" />

    <Block Type="MyObjectBuilder_OxygenTank" Subtype="" />
    <Block Type="MyObjectBuilder_OxygenTank" Subtype="OxygenTankSmall" />
    <Block Type="MyObjectBuilder_OxygenTank" Subtype="LargeHydrogenTank" />
    <Block Type="MyObjectBuilder_OxygenTank" Subtype="LargeHydrogenTankSmall" />
    <Block Type="MyObjectBuilder_OxygenTank" Subtype="SmallHydrogenTank" />
    <Block Type="MyObjectBuilder_OxygenTank" Subtype="SmallHydrogenTankSmall" />
    <Block Type="MyObjectBuilder_OxygenTank" Subtype="LargeHydrogenTankIndustrial" />

    <Block Type="MyObjectBuilder_OxygenFarm" Subtype="LargeBlockOxygenFarm" />

    <Block Type="MyObjectBuilder_AirVent" Subtype="" />
    <Block Type="MyObjectBuilder_AirVent" Subtype="SmallAirVent" />



);
$Builder = "CubeBlock"

$TextBlock =                    '<BlockId Type="MyObjectBuilder_wwwww" Subtype="xxxxx" />'

foreach ($Block in $BlockIds)
{
$temp = $TextBlock -replace "wwwww", $Builder
$temp = $temp -replace "xxxxx", $Block
Write-Host $temp

}
