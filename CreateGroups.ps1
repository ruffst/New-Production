$BlockIds = @(

    'LargeBlockSmallContainer_Gold'
    'SmallBlockSmallContainer_Gold'
    'LargeBlockSmallContainer_Platin'
    'SmallBlockSmallContainer_Platin'
    'LargeBlockSmallContainer_Titan'
    'SmallBlockSmallContainer_Titan'

);
$Builder = "CargoContainer"

$TextBlock =                    '<BlockId Type="MyObjectBuilder_wwwww" Subtype="xxxxx" />'

foreach ($Block in $BlockIds)
{
$temp = $TextBlock -replace "wwwww", $Builder
$temp = $temp -replace "xxxxx", $Block
Write-Host $temp

}
